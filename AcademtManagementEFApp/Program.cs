using AcademtManagementEFApp.Context;
using AcademtManagementEFApp.Helpers;
using AcademtManagementEFApp.Models;
using AcademtManagementEFApp.Services.Concretes;

namespace AcademtManagementEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                FistName = "Togrul",
                LastName = "Bagirov",
                EnrollmentDate = new DateTime(2024, 02, 02),
                CreatedDate =DateTime.Now,
                Username = "Togrul12345",
                DOB = new DateTime(2005, 07, 05),
                Password = "123478",
                IsDeleted =false


            };
            StudentService service= new StudentService();
            


            Console.WriteLine(service.GetStudentById(1).FistName);
            service.UpdateStudent(1, student);


        }
    }
}
