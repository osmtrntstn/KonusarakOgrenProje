using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ExamQuestionOption : Entity<int>
    {
        public int ExamQuestionId { get; set; }
        public virtual ExamQuestion ExamQuestion { get; set; }

        public string Text { get; set; }
        public string OptionType { get; set; }

    }
}
