using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using Entities.Dtos.SessionDtos;
using Entities.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public SessionModelDto LoginControl(UserLoginDto userLogin)
        {
            SessionModelDto sessionModel = new SessionModelDto();
            
            if (String.IsNullOrEmpty(userLogin.UserName) ||String.IsNullOrEmpty(userLogin.Password))
            {
                sessionModel.ResponseMessage = "Kullanıcı Girişi Başarısız Oldu. Kullanıcı Adı veya Şifrenizi Boş Geçmeyiniz.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
                return sessionModel;
            }
            string password = EncryptionHelper.Md5Crypto(userLogin.Password);
            var user = _userDal.Table.Where(x => x.UserName == userLogin.UserName && x.Password == password).Include(x=>x.UserType).FirstOrDefault();
            if (user != null)
            {
               
                sessionModel.UserId = user.Id;
                sessionModel.UserName = user.UserName;
                sessionModel.Name = user.Name;
                sessionModel.UserTypeCode = user.UserType.Code;
                if (user.Status)
                {
                    sessionModel.ResponseMessage = "Kullanıcı Girişi Başarılı";
                    sessionModel.StatusCode = "success";
                    sessionModel.Status = true;

                }
                else
                {
                    sessionModel.ResponseMessage = "Kullanıcı Girişi Başarısız Oldu. Kullanıcı Durumu Onaysız.";
                    sessionModel.StatusCode = "error";
                    sessionModel.Status = false;
                }
            }
            else
            {
                sessionModel.ResponseMessage = "Kullanıcı Girişi Başarısız Oldu. Kullanıcı Adı veya Şifrenizi Kontrol Ediniz.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
            }
            return sessionModel;
        }
    }
}
