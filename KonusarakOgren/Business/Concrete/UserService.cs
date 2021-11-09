using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.SessionDtos;
using Entities.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private IUserTypeDal _userTypeDal;
        private IPasswordCodeDal _passwordCodeDal;
        public UserService(IUserDal userDal,IUserTypeDal userTypeDal, IPasswordCodeDal passwordCodeDal)
        {
            _userDal = userDal;
            _userTypeDal = userTypeDal;
            _passwordCodeDal = passwordCodeDal;
        }

        public SessionModelDto CreateUser(Entities.Concrete.User userLogin)
        {
            SessionModelDto sessionModel = new SessionModelDto();

            if (String.IsNullOrEmpty(userLogin.UserName) ||
                String.IsNullOrEmpty(userLogin.Password) ||
                String.IsNullOrEmpty(userLogin.Email) ||
                String.IsNullOrEmpty(userLogin.Name)
                )
            {
                sessionModel.ResponseMessage = "Kullanıcı Ekleme Başarısız Oldu. Kullanıcı Adı veya Şifrenizi Boş Geçmeyiniz.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
                return sessionModel;
            }
            var checkUser = _userDal.GetAll(x => x.UserName == userLogin.UserName).FirstOrDefault();
            if (checkUser != null)
            {
                sessionModel.ResponseMessage = "Kullanıcı Ekleme Başarısız Oldu. Bu KullanıcıAdı Sistemde Kayıtlı.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
                return sessionModel;
            }
            checkUser = _userDal.GetAll(x => x.Email == userLogin.Email).FirstOrDefault();
            if (checkUser != null)
            {
                sessionModel.ResponseMessage = "Kullanıcı Ekleme Başarısız Oldu. Bu Mail Sistemde Kayıtlı.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
                return sessionModel;
            }
            userLogin.Id = 0;
            userLogin.Status = false;
            userLogin.UserTypeId = 2;
            userLogin.Password = EncryptionHelper.Md5Crypto(userLogin.Password);
            userLogin = _userDal.Add(userLogin);
           
            sessionModel.Name = userLogin.Name;
            sessionModel.Status = true;
            sessionModel.StatusCode = "success";
            sessionModel.UserName = userLogin.UserName;
            sessionModel.UserTypeCode = "us";
            sessionModel.UserId = userLogin.Id;
            return sessionModel;
        }
        public bool ApprovedUser(int id)
        {
            try
            {
                var user = _userDal.GetById(id);
                if (user == null)
                {
                    return false;
                }

                user.Status = true;
                _userDal.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          

        }
        public SessionModelDto LoginControl(UserLoginDto userLogin)
        {
            SessionModelDto sessionModel = new SessionModelDto();

            if (String.IsNullOrEmpty(userLogin.UserName) || String.IsNullOrEmpty(userLogin.Password))
            {
                sessionModel.ResponseMessage = "Kullanıcı Girişi Başarısız Oldu. Kullanıcı Adı veya Şifrenizi Boş Geçmeyiniz.";
                sessionModel.StatusCode = "error";
                sessionModel.Status = false;
                return sessionModel;
            }
            string password = EncryptionHelper.Md5Crypto(userLogin.Password);
            var user = _userDal.Table.Where(x => x.UserName == userLogin.UserName && x.Password == password).Include(x => x.UserType).FirstOrDefault();
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

        public Dto GetCodeUser(string email, string code)
        {
            var user = _userDal.GetAll(x => x.Email.Equals(email)).FirstOrDefault();
            bool err = true;
            string Message = "Mail adresi sisteme kayıtlı bir mail adresi değildir.";
            if (user != null)
            {
                _passwordCodeDal.Add(new PasswordCode { UserId = user.Id, Code = code });
                

            }
            else { err = false; }
            return new Dto
            {
                Status = err,
                ResponseMessage = Message,
            };
        }

        public Dto ChangePassword(ChangePasswrodDto changePasswrod)
        {
            if (String.IsNullOrEmpty(changePasswrod.Code) ||
                  String.IsNullOrEmpty(changePasswrod.Email) ||
                  String.IsNullOrEmpty(changePasswrod.Password) ||
                  String.IsNullOrEmpty(changePasswrod.PasswordConfirm)
                  )
            {
                return new Dto
                {
                    ResponseMessage = "Tüm alanların dolu olduğundan emin olunuz",
                    Status = false,
                    StatusCode = "error"
                };
            }
            if (
                !changePasswrod.Password.Equals(changePasswrod.PasswordConfirm)
                 )
            {
                return new Dto
                {
                    ResponseMessage = "Şifreler Eşleşmemekte",
                    Status = false,
                    StatusCode = "error"
                };
            }

            var user = _userDal.GetAll(x=>x.Email.Equals(changePasswrod.Email)).FirstOrDefault();

            if (user == null)
            {
                return new Dto
                {
                    ResponseMessage = "Mail Adresi Sistemde Bulunamadı.",
                    Status = false,
                    StatusCode = "error"
                };

            }
            user.Password = EncryptionHelper.Md5Crypto(changePasswrod.Password);
            _userDal.Update(user);
            var passwordCode = _passwordCodeDal.GetAll(x => x.Code == changePasswrod.Code && x.UserId == user.Id).FirstOrDefault();
            if (passwordCode != null)
            {
                passwordCode.Status = false;
                _passwordCodeDal.Update(passwordCode);
            }
            return new Dto
            {
                ResponseMessage = "Şifreniz Güncellenmiştir",
                Status = true,
                StatusCode = "success"
            };
        }
    }
}
