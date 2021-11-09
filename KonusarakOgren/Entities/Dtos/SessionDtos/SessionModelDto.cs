using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SessionDtos
{
    public class SessionModelDto : Dto
    {
        public int UserId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime SystemEnteredTime { get; set; } = DateTime.Now;
    }
}
