using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos.ExamDtos;
using Entities.Dtos.SessionDtos;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class AdminHomeController : Controller
    {
        SessionModelDto sessionModel;
        private readonly IWiredTextService _wiredTextService;
        private readonly IExamService _examService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminHomeController(
            IHttpContextAccessor httpContextAccessor,
            IWiredTextService wiredTextService,
            IExamService examService
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _wiredTextService = wiredTextService;
            _examService = examService;
            sessionModel = new Helpers.SessionHelper(_httpContextAccessor).GetSessionModel();
        }
        public IActionResult Index()
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "ad") return RedirectToAction("Index", "UserHome");
            var wiredTextList = _wiredTextService.GetWiredTexts();

            return View(wiredTextList);
        }
        [HttpPost]
        public IActionResult UpdateWiredText(int id, string text)
        {
            if (sessionModel == null) return Unauthorized();
            if (sessionModel.UserTypeCode != "ad") return Unauthorized();

            if (string.IsNullOrEmpty(text))
            {
                return BadRequest(new Dto
                {
                    StatusCode = "error",
                    ResponseMessage = "Text Alanı Boş Geçilemez",
                    Status = false
                });
            }
            var response = _wiredTextService.UpdateWiredText(id,text);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        public IActionResult ExamList()
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "ad") return RedirectToAction("Index", "UserHome");
            var examList = _examService.GetExamList();

            return View(examList);
        }
        public IActionResult CreateExam(int id)
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "ad") return RedirectToAction("Index", "UserHome");
            var wiredText = _wiredTextService.GetWiredText(id);

            return View(wiredText);

        }
        [HttpPost]
        public IActionResult CreateExam(CreateExamDto exam)
        {
            if (sessionModel == null) return RedirectToAction("Index", "Login");
            if (sessionModel.UserTypeCode != "ad") return RedirectToAction("Index", "UserHome");
            exam.UserId = sessionModel.UserId;
            var response = _examService.CreateExam(exam);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpPost]
        public IActionResult DeleteExam(int id)
        {
            try
            {
                if (sessionModel == null) return Unauthorized();
                if (sessionModel.UserTypeCode != "ad") return Unauthorized();

                var response = _examService.DeleteExam(id);
                if (response.Status)
                {

                    return Ok(new { response = response, target = id });
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception)
            {
                Dto responseModel = new Dto
                {
                    StatusCode = "error",
                    Status = false,
                    ResponseMessage = "Sınav Silme Gerçekleştirilemedi"
                };
                return BadRequest(responseModel);
            }


        }
    }
}
