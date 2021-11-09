using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PasswordCodeService : IPasswordCodeService
    {
        IPasswordCodeDal _passwordCodeDal;
        IUserDal _userDal;

        public PasswordCodeService(
             IPasswordCodeDal passwordCodeDal,
            IUserDal userDal
            )
        {
            _userDal = userDal;
            _passwordCodeDal = passwordCodeDal;
        }
        public bool CheckPasswordCode(string email, string code)
        {
            var passwordcode = _passwordCodeDal.Table.Include(x => x.User).FirstOrDefault(x => x.User.Email == email && x.Code.Equals(code) && x.Status == true);

            if (passwordcode == null)
            {
                return  false;
            }
            else
            {
                if (passwordcode.CreatedDate < DateTime.Now.AddDays(-1))
                {
                    passwordcode.Status = false;
                    _passwordCodeDal.Update(passwordcode);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
