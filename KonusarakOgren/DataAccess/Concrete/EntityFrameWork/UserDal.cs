using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class UserDal : EntityRepositoryBase<User, Context>, IUserDal
    {
        private Context _context;
        public UserDal(Context context) : base(context)
        {
            _context = context;
            if (context.Users.Count() == 0)
            {
                CreateDatabaseFirstUsers();
            }
        }

        public void CreateDatabaseFirstUsers()
        {
            
            UserType userTypeAdmin = new UserType
            {
                Code = "ad",
                Name = "Admin"
            };
            _context.UserTypes.Add(userTypeAdmin);
            _context.SaveChanges();

            User adminUser = new User
            {
                Name = "Admin",
                UserName = "admin",
                Password = EncryptionHelper.Md5Crypto("admin123"),
                UserTypeId = userTypeAdmin.Id
            };
            _context.Users.Add(adminUser);
            _context.SaveChanges();
            UserType userTypeUser = new UserType
            {
                Code = "us",
                Name = "User"
            };
            _context.UserTypes.Add(userTypeUser);
            _context.SaveChanges();
            User firstUser = new User
            {
                Name = "User",
                UserName = "user",
                Password = EncryptionHelper.Md5Crypto("user123"),
                UserTypeId = userTypeAdmin.Id
            };
            _context.Users.Add(firstUser);
            _context.SaveChanges();
        }
    }

}
