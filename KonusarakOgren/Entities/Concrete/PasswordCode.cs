using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PasswordCode:Entity<int>
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Code { get; set; }
    }
}
