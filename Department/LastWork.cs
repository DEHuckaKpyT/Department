using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class LastWork
    {
        public int WorkID { get; set; }
        public DateTime WorkBegin { get; set; }
        public DateTime WorkEnd { get; set; }
        public string Work { get; set; }
        public string WorkPlace { get; set; }
        public int StreetID { get; set; }
        public int WorkHouse { get; set; }
        public int Phone { get; set; }
        public string Reason { get; set; }
    }
}
