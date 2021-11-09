using Entities.Dtos.SessionDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private Business.Helper.SessionHelper sessionHelper;
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            sessionHelper = new Business.Helper.SessionHelper();
        }
        public SessionModelDto GetSessionModel()
        {

            if (_httpContextAccessor.HttpContext.Session.Keys.Count() == 0)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserLoginCookie");
                return null;
            }

            var sessionJson = _httpContextAccessor.HttpContext.Session.GetString("User_Session");
            SessionModelDto sessionModel = sessionHelper.GetSessionModel(sessionJson);

            return sessionModel;
        }
        public bool SetSession(SessionModelDto sessionModel)
        {
            try
            {
                
                var sessionJson = sessionHelper.GetSessionString(sessionModel);
                _httpContextAccessor.HttpContext.Session.SetString("User_Session", sessionJson);


                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
