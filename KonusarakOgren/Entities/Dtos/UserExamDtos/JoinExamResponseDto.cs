using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserExamDtos
{
    public class JoinExamResponseDto
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int UserAnswerId { get; set; }
    }
}
