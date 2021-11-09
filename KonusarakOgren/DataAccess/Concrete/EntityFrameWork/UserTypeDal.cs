using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
   
    public class UserTypeDal : EntityRepositoryBase<UserType, Context>, IUserTypeDal
    {
        private Context _context;
        public UserTypeDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
