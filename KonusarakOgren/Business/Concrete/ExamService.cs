using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ExamDtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ExamService : IExamService
    {
        IWiredTextDal _wiredTextDal;
        IExamDal _examDal;
        IExamQuestionDal _examQuestionDal;
        IExamQuestionOptionDal _examQuestionOptionDal;
        IUserExamDal _userExamDal;
        IUserExamOptionDal _userExamOptionDal;
       
        public ExamService(
             IWiredTextDal wiredTextDal,
            IExamDal examDal,
            IExamQuestionDal examQuestionDal,
            IExamQuestionOptionDal examQuestionOptionDal,
            IUserExamDal userExamDal,
            IUserExamOptionDal userExamOptionDal
            )
        {
            _examDal = examDal;
            _examQuestionDal = examQuestionDal;
            _examQuestionOptionDal = examQuestionOptionDal;
            _userExamDal = userExamDal;
            _userExamOptionDal = userExamOptionDal;
            _wiredTextDal = wiredTextDal;
        }
        public Dto CreateExam(CreateExamDto createExamDto)
        {
            Dto dto = new Dto();

            try
            {
                var wiredText = _wiredTextDal.GetById(createExamDto.WiredTextId);
                if (wiredText == null)
                {
                    dto.Status = false;
                    dto.StatusCode = "error";
                    dto.ResponseMessage = "Wired Text Sistemde Bulunamadı";
                    return dto;
                }
                foreach (var createExamQuestion in createExamDto.Questions)
                {
                    if (String.IsNullOrEmpty(createExamQuestion.QuestionText))
                    {
                        dto.Status = false;
                        dto.StatusCode = "error";
                        dto.ResponseMessage = "Lütfen Soru Alanını Boş Bırakmayınız.";
                        return dto;
                    }
                    if (createExamQuestion.QuestionAnsver == "-1")
                    {
                        dto.Status = false;
                        dto.StatusCode = "error";
                        dto.ResponseMessage = "Lütfen Tüm Sorular İçin Doğru Cevap Alanının Boş Olmadığından Emin Olunuz.";
                        return dto;
                    }
                    foreach (var createExamQuestionOption in createExamQuestion.OuestionOptions)
                    {
                        if (String.IsNullOrEmpty(createExamQuestionOption.Text))
                        {
                            dto.Status = false;
                            dto.StatusCode = "error";
                            dto.ResponseMessage = "Lütfen Tüm Soru Şıklarının Dolu Olduğundan Emin Olunuz.";
                            return dto;
                        }
                    }
                }

                Exam exam = new Exam
                {
                    WiredTextId = wiredText.Id,
                    UserId = createExamDto.UserId
                };
                exam = _examDal.Add(exam);

                foreach (var createExamQuestion in createExamDto.Questions)
                {
                    ExamQuestion examQuestion = new ExamQuestion
                    {
                        ExamId = exam.Id,
                        Question = createExamQuestion.QuestionText
                    };
                    examQuestion = _examQuestionDal.Add(examQuestion);
                    foreach (var createExamQuestionOption in createExamQuestion.OuestionOptions)
                    {
                        ExamQuestionOption examQuestionOption = new ExamQuestionOption
                        {
                            ExamQuestionId = examQuestion.Id,
                            OptionType = createExamQuestionOption.Type,
                            Text = createExamQuestionOption.Text
                        };
                        examQuestionOption = _examQuestionOptionDal.Add(examQuestionOption);
                        if (createExamQuestionOption.Type == createExamQuestion.QuestionAnsver)
                        {
                            examQuestion.AnswerId = examQuestionOption.Id;
                            _examQuestionDal.Update(examQuestion);
                        }
                    }
                }
                dto.Status = true;
                dto.StatusCode = "success";
                dto.ResponseMessage = "Sınav Oluşturma İşlemi Başarıyla Gerçekleştirildi";

                return dto;
            }
            catch (Exception)
            {
                dto.Status = false;
                dto.StatusCode = "error";
                dto.ResponseMessage = "Sistemde Bir Hata Oluştu. Sınav Oluşturulamadı.";
                return dto;
            }


        }

        public Dto DeleteExam(int id)
        {
            try
            {
                var exmas = _examDal.GetById(id);

                var userExams = _userExamDal.GetAll(x => x.ExamId == id).ToList();
                foreach (var item in userExams)
                {
                    var userAnswers = _userExamOptionDal.GetAll(x => x.UserExamId == item.Id).ToList();
                    if (userAnswers.Count() > 0)
                    {
                        _userExamOptionDal.RemoveRange(userAnswers);
                    }
                }
                if (userExams.Count() > 0)
                {
                    _userExamDal.RemoveRange(userExams);
                }


                var questions = _examQuestionDal.GetAll(x => x.ExamId == id).ToList();
                foreach (var item in questions)
                {
                    var answers = _examQuestionOptionDal.GetAll(x => x.ExamQuestionId == item.Id).ToList();
                    _examQuestionOptionDal.RemoveRange(answers);
                }
                _examQuestionDal.RemoveRange(questions);
                _examDal.Remove(exmas);
                Dto responseModel = new Dto
                {
                    StatusCode = "success",
                    ResponseMessage = "Sınav Başarılı Bir Şekilde Silindi",
                    Status = true
                };
                return responseModel;
            }
            catch (Exception)
            {
                Dto responseModel = new Dto
                {
                    StatusCode = "error",
                    ResponseMessage = "Sınav Silme Gerçekleştirilemedi",
                    Status = false
                };
                return responseModel;
            }
          


        }

        public List<ExamListDto> GetExamList()
        {
            return _examDal.Table.Include(x=>x.WiredText).Select(x=>new ExamListDto {ExamTitle = x.WiredText.Title,CreatedDate = x.CreatedDate,ExamId = x.Id }).ToList();
        }

        public Exam GetExam(int id)
        {
            var exam = _examDal.Table.Where(x=>x.Id == id).Include(x=>x.ExamQuestions).Include(x=>x.WiredText).FirstOrDefault();
            foreach (var item in exam.ExamQuestions)
            {
                item.ExamQuestionOptions = _examQuestionOptionDal.GetAll(x => x.ExamQuestionId == item.Id).ToList();
            }
            return exam;
        }
    }
}
