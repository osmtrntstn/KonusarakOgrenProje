using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public SessionModelDto CreateUser(User userLogin);
        public Dto ChangePassword(ChangePasswrodDto changePasswrod);
        public bool ApprovedUser(int id);
        public Dto GetCodeUser(string email,string code);

    }
}
