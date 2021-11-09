using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.ExamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        public List<ExamListDto> GetExamList();
        public Exam GetExam(int id);
        public Dto CreateExam(CreateExamDto createExamDto);
        public Dto DeleteExam(int id);
    }
}
