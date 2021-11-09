using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserExam : Entity<int>
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<UserExamOption> UserExamOptions { get; set; }
    }
}
