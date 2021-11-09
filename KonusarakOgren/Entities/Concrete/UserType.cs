using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserType : Entity<short>
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
    }
}
