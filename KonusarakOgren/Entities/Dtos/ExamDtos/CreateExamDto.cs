using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ExamDtos
{
    public class CreateExamDto
    {
        public int WiredTextId { get; set; }
        public int UserId { get; set; } = 0;
        public List<CreateExamQuestionDto> Questions { get; set; }
    }
}
