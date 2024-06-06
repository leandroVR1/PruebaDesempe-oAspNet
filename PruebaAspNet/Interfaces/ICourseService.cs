using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaAspNet.Models;

namespace PruebaAspNet.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int Id);
        Task<Course> PostCourse(Course course);
        Task<Course> PutCourse(int Id, Course course);

        Task<Course> DeleteCourse(int id);
        
    }
}