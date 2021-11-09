using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ExamDtos
{
    public class ExamListDto
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
