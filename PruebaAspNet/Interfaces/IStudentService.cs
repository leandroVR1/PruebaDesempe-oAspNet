using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaAspNet.Models;

namespace PruebaAspNet.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int Id);
        Task<Student> PostStudent(Student student);
        Task<Student> PutStudent(int Id, Student student);

        Task<Student> DeleteStudent(int id);
       //GetStudentsByBirthDate
        Task<IEnumerable<Student>> GetStudentsByBirthDate(DateTime birthDate);
        Task<IEnumerable<Enrollment>> GetEnrollmentsOfStudent(int studentId);
        
    }
}