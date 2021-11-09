using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPasswordCodeService
    {
        public bool CheckPasswordCode(string email, string code);
    }
}
