using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Exceptions
{
    public class AppointmentException:Exception
    {
        public AppointmentException() : base("format duzgun deyil")
        {
            
        }
        public AppointmentException(string message):base(message)
        {
            
        }
    }
}
