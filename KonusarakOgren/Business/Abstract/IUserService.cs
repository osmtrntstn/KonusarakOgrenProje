using DataAccess.Abstract;
using Entities.Dtos.SessionDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public SessionModelDto LoginControl(UserLoginDto userLogin);
    }
}
