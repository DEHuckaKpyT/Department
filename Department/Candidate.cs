using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class Candidate
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int StreetID { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public int WorkID { get; set; }
        public int PostID { get; set; }
        public bool Adopted { get; set; }
    }
}
