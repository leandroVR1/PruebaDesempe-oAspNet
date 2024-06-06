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
    public class EnrollmentService : IEnrollmentService
    {

          // Contexto de base de datos para interactuar con la base de datos.
        private readonly BaseContext _context;

        // Constructor que inicializa el contexto de base de datos.
        public EnrollmentService(BaseContext context)
        {
            _context = context;
        }
      


        // Método para obtener todos los matriculas disponibles de la base de datos.
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await _context.enrollments.ToListAsync();
        }
        
       
      
     
        // Método para crear una nueva matricula en la base de datos.
        public async Task<Enrollment> PostEnrollment(Enrollment enrollment)
        {
            _context.enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }
       
     
      

        // Método para actualizar una matricula en la base de datos.
        public async Task<Enrollment> PutEnrollment(int Id, Enrollment enrollment)
        {
            var existingEnrollment = await _context.enrollments.FindAsync(Id);
            if (existingEnrollment == null)
            {
                return null;
            }

            existingEnrollment.StudentId = enrollment.StudentId;
            existingEnrollment.CourseId = enrollment.CourseId;
            existingEnrollment.Course = enrollment.Course;
            existingEnrollment.Student = enrollment.Student;
            existingEnrollment.Date = enrollment.Date;

            await _context.SaveChangesAsync();
            return existingEnrollment;
        }
        

       
      
        // Método para obtener una matricula por su Id
        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            return await _context.enrollments.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Metodo para obtener  lista de matriculas que se realizaron en una fecha en especifico
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByDate(DateTime date)
        {
            return await _context.enrollments.Where(e => e.Date == date).ToListAsync();
        }
       
        
       

      

    
        
    }
}