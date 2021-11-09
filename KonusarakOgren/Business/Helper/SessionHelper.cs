using Core.Utilities.Security.Encryption;
using Entities.Dtos.SessionDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public class SessionHelper
    {

        public SessionModelDto GetSessionModel(string sessionJson)
        {
            sessionJson = EncryptionHelper.Decode(sessionJson);
            SessionModelDto sessionModel = (SessionModelDto)JsonConvert.DeserializeObject(sessionJson, typeof(SessionModelDto));
            return sessionModel;
        }

        public string GetSessionString(SessionModelDto sessionModel)
        {
            string sessionJson = JsonConvert.SerializeObject(sessionModel);
            sessionJson = EncryptionHelper.Encode(sessionJson);
            return sessionJson;
        }
    }
}
