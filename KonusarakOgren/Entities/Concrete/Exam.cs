using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Exam:Entity<int>
    {
        public int WiredTextId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual WiredText WiredText { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
