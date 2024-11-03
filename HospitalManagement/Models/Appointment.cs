using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Appointment
    {
        private static int _count;
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Appointment()
        {
            _count++;
            Id = _count;
            StartDate = DateTime.Now; 
        }
    }
}