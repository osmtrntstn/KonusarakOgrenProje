using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.WiredDtos
{
    public class WiredUrlDto : IDto
    {
        public string ResponseMessage { get; set; }
        public bool Status { get; set; }
        public string StatusCode { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}
