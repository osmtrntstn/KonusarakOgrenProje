using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserExamOption : Entity<int>
    {
        public int UserExamId { get; set; }
        public virtual UserExam UserExam { get; set; }
        public int ExamQuestionOptionId { get; set; }
        public virtual ExamQuestionOption ExamQuestionOption { get; set; }
        public int ExamQuestionId { get; set; }
        public virtual ExamQuestion ExamQuestion { get; set; }
    }
}
