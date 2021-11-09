using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.SessionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class UserHomeController : Controller
    {
        SessionModelDto sessionModel;
        private readonly IUserExamService _userExamService;
        private readonly IExamService _examService;
        public UserHomeController(IHttpContextAccessor httpContextAccessor,IUserExamService userExamService, IExamService examService)
        {
            _userExamService = userExamService;
            _examService = examService;
            sessionModel = new Helpers.SessionHelper(httpContextAccessor).GetSessionModel();
        }
        public IActionResult Index()
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "us") return RedirectToAction("Index", "AdminHome");
            var examList = _examService.GetExamList();
            return View(examList);
        }
        public IActionResult JoinExam(int id)
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "us") return RedirectToAction("Index", "AdminHome");
            var chectUserExam = _userExamService.CheckUserExam(id,sessionModel.UserId);
            if (!chectUserExam.Status)
            {
                return View("Error");
            }
            var exam = _examService.GetExam(id);
            if(exam == null) return RedirectToAction("Index", "UserHome");
            return View(exam);
        } 
        [HttpPost]
        public IActionResult JoinExam(UserExam userExam)
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "us") return RedirectToAction("Index", "AdminHome");
            var chectUserExam = _userExamService.CheckUserExam(userExam.ExamId,sessionModel.UserId);
            if (!chectUserExam.Status)
            {
                Dto dto = new Dto
                {
                    Status = false,
                    StatusCode = "error",
                    ResponseMessage = "Aynı Sınava İki Kez Giremezsiniz"
                };
                return BadRequest(dto);
            }
            foreach (var item in userExam.UserExamOptions)
            {
                if (item.ExamQuestionOptionId == 0)
                {
                    Dto dto = new Dto
                    {
                        Status = false,
                        StatusCode = "error",
                        ResponseMessage = "Lütfen Tüm Soruları Cevaplayınız"
                    };
                    return BadRequest(dto);
                }
            }
            userExam.UserId = sessionModel.UserId;

            var response = _userExamService.SaveUserExam(userExam);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult GetExamStatus(int id)
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "us") return RedirectToAction("Index", "AdminHome");
            var userExam = _userExamService.CheckUserExam(id,sessionModel.UserId);
            if (userExam.Status)
            {
                return Ok(new { result = "(" + userExam.ConfirmCount + " / 4" + ")" });
            }
            else
            {
                return Ok(new { result = "<a href=\"/UserHome/JoinExam/" + id + "\">Sınava Katıl</a>" });
            }
        }
    }
}
