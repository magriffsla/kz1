using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kz1.Models
{
    public class RegaVM
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirm { get; set; }
        public bool remember { get; set; }
    }
}
