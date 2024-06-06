// Simulacro2.Services/MedicoService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaAspNet.Data;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Services
{
    // Implementación del servicio de cursos que implementa la interfaz ICursoService.
    public class CourseService : ICourseService
    {
        // Contexto de base de datos para interactuar con la base de datos.
        private readonly BaseContext _context;

        // Constructor que inicializa el contexto de base de datos.
        public CourseService(BaseContext context)
        {
            _context = context;
        }


        // Método para obtener todos los cursos disponibles de la base de datos.
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.courses.ToListAsync();
        }
      
     
        // Método para crear un nuevo curso en la base de datos.
        public async Task<Course> PostCourse(Course course)
        {
            _context.courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
     
      

        // Método para actualizar un curso en la base de datos.
        public async Task<Course> PutCourse(int Id, Course course)
        {
            var existingCourse = await _context.courses.FindAsync(Id);
            if (existingCourse == null)
            {
                return null;
            }
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Duration = course.Duration;
            existingCourse.Schedule = course.Schedule;

            await _context.SaveChangesAsync();
            return existingCourse;
        }
      
        // Método para obtener un curso por su Id
        public async Task<Course> GetCourseById(int id)
        {
            return await _context.courses.FirstOrDefaultAsync(c => c.Id == id);
        }
        
       

      

        // Método para eliminar un curso de la base de datos.
        public async Task<Course> DeleteCourse(int id)
        {
            var existingCourse = await _context.courses.FindAsync(id);
            if (existingCourse == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return existingCourse;
        }
      
      





    }
}
