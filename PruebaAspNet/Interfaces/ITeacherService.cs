using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaAspNet.Models;


namespace PruebaAspNet.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> PostTeacher(Teacher teacher);
        Task<Teacher> PutTeacher(int Id, Teacher teacher);
        Task<IEnumerable<Course>> GetCoursesOfTeacher(int teacherId);
        
      
       
    }
}