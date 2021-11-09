using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ExamDtos
{
    public class CreateExamQuestionDto
    {
        public string QuestionText { get; set; }
        public List<CreateExamQuestionOptionDto> OuestionOptions { get; set; }
        public string QuestionAnsver { get; set; }
    }
}
