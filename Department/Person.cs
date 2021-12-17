using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? DepartmentID { get; set; }
        public int? InstituteID { get; set; }
        public string Passport { get; set; }
        public DateTime PassportDate { get; set; }
        public string Region { get; set; }
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
        public int? StreetID { get; set; }
        public int? House { get; set; }
        public int? Flat { get; set; }
        public string Speciality { get; set; }
        public int? PostID { get; set; }
        public string Education { get; set; }
        public DateTime Year { get; set; }
        public bool? DegreeYes { get; set; }
        public int? DegreeID { get; set; }
        public string Rank { get; set; }
        public int WorkID { get; set; }
        public string Comment { get; set; }
    }
}
