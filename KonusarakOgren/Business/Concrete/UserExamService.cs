using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using Entities.Dtos.UserExamDtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserExamService : IUserExamService
    {
        IUserExamDal _userExamDal;
        IUserExamOptionDal _userExamOptionDal;
        IExamDal _examDal;
        IExamQuestionDal _examQuestionDal;
        Context _context;
        public UserExamService(IUserExamDal userExamDal, IUserExamOptionDal userExamOptionDal,IExamDal examDal, IExamQuestionDal examQuestionDal,Context context)
        {
            _userExamDal = userExamDal;
            _examDal = examDal;
            _userExamOptionDal = userExamOptionDal;
            _examQuestionDal = examQuestionDal;
        }
        public CheckUserExamDto CheckUserExam(int id)
        {
            CheckUserExamDto checkUserExamDto = new CheckUserExamDto();
            var userExam = _userExamDal.Table.Where(x=>x.ExamId == id).FirstOrDefault();
            if (userExam == null)
            {
                checkUserExamDto.Status = false;
                return checkUserExamDto;
            }
            int confirms = 0;
            int wrongs = 0;
            var exams = _examDal.Table.Where(x => x.Id == id).Include(x => x.ExamQuestions).FirstOrDefault();
            var userAnswers = _userExamOptionDal.GetAll(x => x.UserExamId == userExam.Id).ToList();
            foreach (var userAnswer in userAnswers)
            {
                var examQuestion = _examQuestionDal.GetAll(x => x.Id == userAnswer.ExamQuestionId && x.AnswerId == userAnswer.ExamQuestionOptionId).FirstOrDefault();
                if (examQuestion == null)
                {
                    wrongs++;
                }
                else
                {
                    confirms++;
                }
            }
            checkUserExamDto.Status = true;
            checkUserExamDto.WrongCount = wrongs;
            checkUserExamDto.ConfirmCount = confirms;
            return checkUserExamDto;
        }

        public List<JoinExamResponseDto> SaveUserExam(UserExam userExam)
        {
            userExam.Id = 0;
            List<JoinExamResponseDto> responseDtos = new List<JoinExamResponseDto>();
            UserExam exam = new UserExam
            {
                ExamId = userExam.ExamId,
                UserId = userExam.UserId
            };
            exam = _userExamDal.Add(exam);
            foreach (var item in userExam.UserExamOptions)
            {
                item.UserExamId = exam.Id;
                _userExamOptionDal.Add(item);

                var questionResult = _examQuestionDal.GetAll(x => x.Id == item.ExamQuestionId).FirstOrDefault();
                responseDtos.Add(new JoinExamResponseDto
                {
                    QuestionId = item.ExamQuestionId,
                    AnswerId = questionResult.AnswerId,
                    UserAnswerId = item.ExamQuestionOptionId
                });
            }
            return responseDtos;
        }
    }
}
