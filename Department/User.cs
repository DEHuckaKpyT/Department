using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }
        public bool CanSeeUsers { get; set; }
        public bool CanChangeInf { get; set; }
        public bool CanSeeLog { get; set; }
    }
}
