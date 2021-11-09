using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class ResetPasswordDto
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Mail { get; set; }
    }
}
