using Entities.Concrete;
using Entities.Dtos.UserExamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserExamService
    {
        public CheckUserExamDto CheckUserExam(int id);
        public List<JoinExamResponseDto> SaveUserExam(UserExam userExam);
    }
}
