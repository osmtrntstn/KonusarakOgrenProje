using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.MailDtos;
using Entities.Dtos.SessionDtos;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class LoginController : Controller
    {
        SessionModelDto sessionModel;
        private readonly IUserService _userService;
        private readonly IPasswordCodeService _passwordCodeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor, IUserService userService, IPasswordCodeService passwordCodeService)
        {
            _userService = userService;
            _passwordCodeService = passwordCodeService;
            _httpContextAccessor = httpContextAccessor;
            sessionModel = new Helpers.SessionHelper(_httpContextAccessor).GetSessionModel();
        }
        public IActionResult Index()
        {
            if (sessionModel != null)
            {
                if (sessionModel.UserTypeCode == "ad")
                    return RedirectToAction("Index", "AdminHome");
                else if (sessionModel.UserTypeCode == "us")
                    return RedirectToAction("Index", "UserHome");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Index(UserLoginDto userLogin)
        {
            var sessionModel = _userService.LoginControl(userLogin);
            if (sessionModel.Status)
            {
                Helpers.SessionHelper sessionHelper = new Helpers.SessionHelper(_httpContextAccessor);
                bool response = sessionHelper.SetSession(sessionModel);
                if (response)
                {
                    if (sessionModel.UserTypeCode == "ad")
                        return RedirectToAction("Index", "AdminHome");
                    else if (sessionModel.UserTypeCode == "us")
                        return RedirectToAction("Index", "UserHome");
                }
                else
                {
                    ResponseModelDto responseModel = new ResponseModelDto
                    {
                        ResponseMessage = "Kullanıcı Girişi Başarısız Oldu. Oturum Bilgileri İşlenemedi.",
                        Status = false,
                        StatusCode = "error"
                    };
                    return BadRequest(responseModel);
                }
            }
            else
            {
                ResponseModelDto responseModel = new ResponseModelDto
                {
                    ResponseMessage = sessionModel.ResponseMessage,
                    Status = sessionModel.Status,
                    StatusCode = sessionModel.StatusCode
                };
                return BadRequest(responseModel);
            }
            return View();
        }
        public IActionResult ForgotPassword()
        {
            if (sessionModel != null)
            {
                return RedirectToAction("Index", "AdminHome");
            }
            return View();

        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (sessionModel != null)
            {
                return RedirectToAction("Index", "AdminHome");
            }

            string code = Guid.NewGuid().ToString();
            ViewBag.Mail = email;

            ResetPasswordDto resetPasswordModel = new ResetPasswordDto
            {
                Code = code,
                Mail = email
            };
            string token = JsonConvert.SerializeObject(resetPasswordModel);
            token = Core.Utilities.Security.Encryption.EncryptionHelper.Encode(token);
            token = token.Replace("+", "%2B");
            SendMailDto sendMailDto = new SendMailDto
            {
                ReciverMail = email,
                Body = "<h1><a href=\"https://localhost:44331/reset-password?token=" + token + "\">Sıfırlamak için tıklayınız</a></h1> ",
                Title = "Parola Sıfırlama"
            };
            var passwordCode = _passwordCodeService.CheckPasswordCode(email, code);
            if (passwordCode)
            {

                var sendResponse = SendMail(sendMailDto);
            }
            else
            {
                var user = _userService.GetCodeUser(email, code);
                if (user.Status)
                {
                    var sendResponse = SendMail(sendMailDto);

                }
            }

            return RedirectToAction("Index", "Login");

        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Session");

            return RedirectToAction("Index", "Login");
        }

        [Route("create-user")]
        public IActionResult CreateUser()
        {

            return View();
        }
        [Route("create-user")]
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (sessionModel != null)
            {
                if (sessionModel.UserTypeCode == "ad")
                    return RedirectToAction("Index", "AdminHome");
                else if (sessionModel.UserTypeCode == "us")
                    return RedirectToAction("Index", "UserHome");
            }
            var cretedUser = _userService.CreateUser(user);
            if (!cretedUser.Status)
            {
                return BadRequest(cretedUser);
            }
            string token = JsonConvert.SerializeObject(cretedUser);
            token = Core.Utilities.Security.Encryption.EncryptionHelper.Encode(token);
            token = token.Replace("+", "%2B");
            SendMailDto sendMailDto = new SendMailDto
            {
                Title = "Hesap Onaylama",
                Body = "<div><a href=\"https://localhost:44331/approved-user?token=" + token + "\">Hesabı Onaylamak İçin Tıklayınız</a></div>",
                ReciverMail = user.Email
            };
            sendMailDto = SendMail(sendMailDto);
            if (sendMailDto.Status)
            {

                return Ok(sendMailDto);
            }
            else
            {
                return BadRequest(sendMailDto);
            }
        }
        [Route("approved-user")]
        public IActionResult ApprovedUser(string token)
        {
            try
            {
                if (sessionModel != null)
                {
                    if (sessionModel.UserTypeCode == "ad")
                        return RedirectToAction("Index", "AdminHome");
                    else if (sessionModel.UserTypeCode == "us")
                        return RedirectToAction("Index", "UserHome");
                }
                token = Core.Utilities.Security.Encryption.EncryptionHelper.Decode(token);
                SessionModelDto setSessionModel = (SessionModelDto)JsonConvert.DeserializeObject(token, typeof(SessionModelDto));
                bool aproved = _userService.ApprovedUser(setSessionModel.UserId);
                if (aproved)
                {
                    Helpers.SessionHelper sessionHelper = new Helpers.SessionHelper(_httpContextAccessor);
                    bool response = sessionHelper.SetSession(setSessionModel);

                    return RedirectToAction("index", "userhome");

                }
                else
                {
                    return RedirectToAction("index", "login");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("index", "login");
            }



        }
        [Route("reset-password")]
        public IActionResult ResetPassword(string token)
        {
            if (sessionModel != null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            if (!String.IsNullOrEmpty(token))
            {
                try
                {
                    token = Core.Utilities.Security.Encryption.EncryptionHelper.Decode(token);
                    ResetPasswordDto model = (ResetPasswordDto)JsonConvert.DeserializeObject(token, typeof(ResetPasswordDto));
                    if (model == null) return View("index");
                    if (String.IsNullOrEmpty(model.Code)) return View("index");
                    if (String.IsNullOrEmpty(model.Mail)) return View("index");

                    if (_passwordCodeService.CheckPasswordCode(model.Code, model.Mail)) return View("index");

                    ViewBag.Token = model.Code;
                    ViewBag.Mail = model.Mail;
                    return View(model);
                }
                catch (Exception e)
                {

                    return View("index");
                }

            }
            return View("index");

        }
        [Route("reset-password")]
        [HttpPost]
        public IActionResult ResetPassword(ChangePasswrodDto changePasswrod)
        {
            if (sessionModel != null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            var response = _userService.ChangePassword(changePasswrod);
            if (response.Status)
            {

                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        private SendMailDto SendMail(SendMailDto sendMail)
        {
            try
            {
                MailMessage msg = new MailMessage("osman.konusrakogren@gmail.com", sendMail.ReciverMail, sendMail.Title, sendMail.Body);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("osman.konusarakogren@gmail.com", "osman.konusarakogren_2021");
                sc.Credentials = cre;
                sc.EnableSsl = true;

                sc.Send(msg);
                sendMail.Status = true;
                sendMail.ResponseMessage = "Mail adresininize gelen epostayı onayladıktan sonra sisteme giriş yapabilirsiniz.";
                sendMail.StatusCode = "success";
                return sendMail;
            }
            catch (Exception e)
            {
                sendMail.Status = false;
                sendMail.ResponseMessage = "Mail adresininize gönderim sağlanamadı.";
                sendMail.StatusCode = "error";

                return sendMail;
            }

        }
    }
}
