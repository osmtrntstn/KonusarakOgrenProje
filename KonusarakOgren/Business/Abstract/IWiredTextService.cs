using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.WiredDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWiredTextService
    {
        public List<WiredDto> GetWiredTexts();
        public WiredText GetWiredText(int id);
        public Dto UpdateWiredText(int id,string text);

    }
}
