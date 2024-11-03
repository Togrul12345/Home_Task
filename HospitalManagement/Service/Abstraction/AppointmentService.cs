using HospitalManagement.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Concrete
{
    public class AppointmentService : IAppointmentService
    {

        private readonly List<Appointment> _appointments;

        public AppointmentService()
        {
            _appointments = [];
        }
        public override string ToString()
        {string str=string.Empty; 
            foreach (Appointment appointment in _appointments)
            {
                 str += $"{appointment.DoctorName} qebulunda {appointment.PatientName} adinda xeste oldu\n";

            }
            return str;
        }
        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
            
        }
                    

        public void EndAppointment(int id)
        {
            
            for (int i = 0; i < _appointments.Count; i++) {
               
                
                if (_appointments[i].Id == id)
                {

                    _appointments[i].EndDate = DateTime.Now;
                    Console.WriteLine("Randevu sonlandi");
                    return;
                }
            
            }
            throw new AppointmentException($"{id}-idisine uygun randevu tapilmadi");
           
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }

        public List<Appointment> GetAllContinuingAppointments()
        {List<Appointment> continousAppointment=new List<Appointment>();
            for(int i = 0;i < _appointments.Count; i++)
            {
                if (_appointments[i].EndDate < DateTime.Now)
                {
                    continousAppointment.Add(_appointments[i]);
                }
            }
            return continousAppointment;
        }

        public Appointment GetAppointment(int id)
        {
            int index = -1;
            bool isFound = false;
            for (int i = 0; i < _appointments.Count; i++)
            {


                if (_appointments[i].Id == id)
                {
                    isFound = true;
                    index = i;
                    break;
                }

            }
            if (isFound)
            {
                return _appointments[index];
            }
            else
            {
                throw new Exception($"{id}-appointment tapilmadi");
            }

        }

        public List<Appointment> GetTodaysAppointments()
        {List<Appointment> today_appointments=new List<Appointment>();
            for (int i = 0; i < _appointments.Count; i++)
            {
                if (_appointments[i].StartDate == DateTime.Now)
                {
                    today_appointments.Add(_appointments[i]);

                }
            }
            return today_appointments;
        }

        public List<Appointment> GetWeeklyAppointments()
        {
            List<Appointment> weakly_appointments = new List<Appointment>();
            for (int i = 0; i < _appointments.Count; i++)
            {
                if (_appointments[i].StartDate<= DateTime.Now&& _appointments[i].StartDate>=DateTime.Now.AddDays(-7))
                {
                    weakly_appointments.Add(_appointments[i]);

                }
            }
            return weakly_appointments;
        }

      
    }
}
