using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademtManagementEFApp.Models
{
    public class Student:BaseEntity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
