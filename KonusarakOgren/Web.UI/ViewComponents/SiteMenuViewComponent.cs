using Entities.Dtos.SessionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.ViewComponents
{
    public class SiteMenuViewComponent:ViewComponent
    {
        SessionModelDto sessionModel;
        public SiteMenuViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            sessionModel = new Helpers.SessionHelper(httpContextAccessor).GetSessionModel();
        }
        public IViewComponentResult Invoke()
        {
            if (sessionModel != null)
            {
                ViewBag.UserType = sessionModel.UserTypeCode;
                return View();
            }
            return null;
        }
    }
}
