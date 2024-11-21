using AcademtManagementEFApp.Context;
using AcademtManagementEFApp.Models;
using AcademtManagementEFApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademtManagementEFApp.Services.Concretes
{
    internal class StudentService : IStudentService
    {
        AppDBContext _dbContext = new();
        public void CreateStudent(Student student)
        {
            _dbContext.Students.Add(student);
            int row = _dbContext.SaveChanges();
            if (row > 0)

            {
                Console.WriteLine($"{row} row successfully added");

            }
            else
            {
                throw new Exception("something went wrong");
            }
        }

        public List<Student> GetAllActiveStudents()
        {
            return _dbContext.Students.Where(a => a.IsDeleted == false).ToList();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public List<Student> GetStudensByEnrollmentDate(int days)
        {
            return _dbContext.Students.Where(a => a.EnrollmentDate > DateTime.Now.AddDays(-days)).ToList();
        }

        public Student GetStudentById(int id)
        {
            Student? student = _dbContext.Students.Find(id);
            if (student == null)
            {
                Console.WriteLine("tapilmadi");
                return null;
            }
            else
            {
                return student;
            }
            
        }

        public List<Student> GetStudentsByName(string name)
        {
            return _dbContext.Students.Where(a => a.FistName == name).ToList();
        }

        public void HardDeleteStudent(int id)
        {
            Student removedStudent = _dbContext.Students.Where(a => a.Id == id).First();
            _dbContext.Remove(removedStudent);
            _dbContext.SaveChanges();
        }

        public void SoftDeleteStudent(int id)
        {
            foreach (var item in _dbContext.Students.Where(a => a.Id == id))
            {
                item.IsDeleted = true;

            }
        }

        public void UpdateStudent(int id, Student student)
        {
            var updatedStudent = _dbContext.Students.FirstOrDefault(a => a.Id == id);
            if (updatedStudent != null) { 

            updatedStudent.FistName=student.FistName;
                updatedStudent.LastName=student.LastName;

                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("student not found");
            }




           





        }
    }
}
