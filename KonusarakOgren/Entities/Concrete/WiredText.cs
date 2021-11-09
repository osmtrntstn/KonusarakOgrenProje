using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WiredText:Entity<int>
    {
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(250)]
        public string TextUrl { get; set; }
        public string Text { get; set; }
    }
}
