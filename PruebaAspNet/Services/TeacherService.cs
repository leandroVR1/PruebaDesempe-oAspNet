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
    // Implementación del servicio de profesores que implementa la interfaz ITeacherService.
    public class TeacherService : ITeacherService
    {
        // Contexto de base de datos para interactuar con la base de datos.
        private readonly BaseContext _context;

        // Constructor que inicializa el contexto de base de datos.
        public TeacherService(BaseContext context)
        {
            _context = context;
        }


        // Método para obtener todos los profesores disponibles de la base de datos.
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.teachers.ToListAsync();
        }
     
        // Método para crear un nuevo profesor en la base de datos.
        public async Task<Teacher> PostTeacher(Teacher teacher)
        {
            _context.teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
      

        // Método para actualizar un campo o varios campos de profesor en la base de datos.
        public async Task<Teacher> PutTeacher(int Id, Teacher teacher)
        {
            var existingTeacher = await _context.teachers.FindAsync(Id);
        
            if (existingTeacher == null)
            {
                return null;
            }
           
            

            existingTeacher.Names = teacher.Names;
            existingTeacher.Speciality = teacher.Speciality;
            existingTeacher.Phone = teacher.Phone;
            existingTeacher.Email = teacher.Email;
            existingTeacher.YearsExperience = teacher.YearsExperience;
            await _context.SaveChangesAsync();
            return existingTeacher;
        }
       

      //Método para obtener un profesor por su Id
      public async Task<Teacher> GetTeacherById(int id)
        {
            return await _context.teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        // Método para eliminar un profesor de la base de datos.
        public async Task<Teacher> DeleteTeacher(int id)
        {
            var existingTeacher = await _context.teachers.FindAsync(id);
            if (existingTeacher == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return existingTeacher;
        }
        //Metodo para obtener lista de las cursos que tiene un profesor
        public async Task<IEnumerable<Course>> GetCoursesOfTeacher(int teacherId)
        {
            return await _context.courses.Where(c => c.TeacherId == teacherId).ToListAsync();
        }
      





    }
}
