using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserExamDtos
{
    public class CheckUserExamDto:IDto
    {
        public string ResponseMessage { get; set; }
        public bool Status { get; set; }
        public string StatusCode { get; set; }
        public int ConfirmCount { get; set; } = 0;
        public int WrongCount { get; set; } = 0;
    }
}
