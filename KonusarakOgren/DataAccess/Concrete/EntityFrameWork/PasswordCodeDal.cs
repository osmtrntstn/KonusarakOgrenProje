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
    public class PasswordCodeDal : EntityRepositoryBase<PasswordCode, Context>, IPasswordCodeDal
    {
        private Context _context;
        public PasswordCodeDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
