using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.SessionDtos;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class LoginController : Controller
    {
        SessionModelDto sessionModel;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            sessionModel = new Helpers.SessionHelper(_httpContextAccessor).GetSessionModel();
        }
        public IActionResult Index()
        {
            if (sessionModel != null)
            {
               if(sessionModel.UserTypeCode == "ad")
                    return RedirectToAction("Index", "AdminHome");
               else if(sessionModel.UserTypeCode == "us")
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
                    if(sessionModel.UserTypeCode == "ad")
                        return RedirectToAction("Index", "AdminHome");
                    else if(sessionModel.UserTypeCode == "us")
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
        [HttpPost]
        public IActionResult CreateUser(User user)
        {

            return View();
        }

    }
}
