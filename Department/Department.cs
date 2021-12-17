using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class Department
    {
        public int DeparmentID { get; set; }
        public string Deparment { get; set; }
        public int InstituteID { get; set; }

        public override string ToString()
        {
            return Deparment;
        }
    }
}
