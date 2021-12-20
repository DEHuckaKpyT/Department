using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class Degrees
    {
        public int DegreeID { get; set; }
        public string Degree { get; set; }

        public override string ToString()
        {
            return Degree;
        }
    }
}
