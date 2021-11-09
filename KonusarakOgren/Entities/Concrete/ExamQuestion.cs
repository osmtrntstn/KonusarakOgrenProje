using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ExamQuestion : Entity<int>
    {
        public string Question { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int AnswerId { get; set; }

        public virtual ICollection<ExamQuestionOption> ExamQuestionOptions { get; set; }

    }
}
