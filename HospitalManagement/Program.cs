using HospitalManagement.Exceptions;
using HospitalManagement.Service.Concrete;

namespace HospitalManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IAppointmentService appointmentservice = new AppointmentService();
            while (true)
            {
                
                Console.WriteLine("1. Appointment yarat\r\n2. Appointment-i bitir\r\n3. Bütün appointment-lərə bax\r\n4. Bu həftəki appointment-lərə bax\r\n5. Bugünki appointment-lərə bax\r\n6. Bitməmiş appointmentlərə bax\r\n7. Menudan çıx");
                string? option = Console.ReadLine();
               
                switch (option)
                {
                    case "1":
                        Appointment appointment = new Appointment();
                       
                        Console.WriteLine("Bitme tarixi teyin et:");
                        try
                        {
                            appointment.EndDate = Convert.ToDateTime(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("xeste adi daxil edin:");
                        appointment.PatientName = Console.ReadLine();
                        Console.WriteLine("doktor adi daxil et");
                        appointment.DoctorName = Console.ReadLine();
                        appointmentservice.AddAppointment(appointment);


                        break;
                    case "2":
                        Console.WriteLine("Which appointment do you want to end?");
                        int option2 = Convert.ToInt32(Console.ReadLine());
                        appointmentservice.EndAppointment(option2);
                        break;
                    case "3":
                        foreach (Appointment item in appointmentservice.GetAllAppointments())
                        {
                            Console.WriteLine($"{item.Id}.{item.PatientName}-{item.DoctorName}-{item.StartDate}-{item.EndDate}");
                        }
                        break;
                    case "4":
                        appointmentservice.GetWeeklyAppointments();
                        break;
                    case "5":
                        appointmentservice.GetTodaysAppointments();
                        break;
                    case "6":
                        appointmentservice.GetAllContinuingAppointments();
                        break;
                    case "7": break;
                }
                Console.WriteLine("Do you want to stop program?");
                if (Console.ReadLine() == "yes")
                {
                    break;
                };
              


            } 
        }
    }
}

