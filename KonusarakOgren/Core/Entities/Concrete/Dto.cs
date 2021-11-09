using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Dto : IDto
    {
        public string ResponseMessage { get; set; }
        public bool Status { get; set; }
        public string StatusCode { get; set; }
    }
}
