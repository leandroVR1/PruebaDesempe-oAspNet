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
    // Implementación del servicio de estudiantes que implementa la interfaz IMedicoService.
    public class StudentService : IStudentService
    {
        // Contexto de base de datos para interactuar con la base de datos.
        private readonly BaseContext _context;

        // Constructor que inicializa el contexto de base de datos.
        public StudentService(BaseContext context)
        {
            _context = context;
        }

        // Método para obtener todos los estudiante disponibles de la base de datos.
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.students.ToListAsync();
        }

        // Método para crear un nuevo estudiante en la base de datos.
        public async Task<Student> PostStudent(Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Método para actualizar un estudiante en la base de datos.
        public async Task<Student> PutStudent(int Id , Student student)
        {
            var existingStudent = await _context.students.FindAsync(Id);
            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.Names = student.Names;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Address = student.Address;
            existingStudent.Email = student.Email;
    
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        // Método para obtener un estudiante por su ID.
        public async Task<Student> GetStudentById(int id)
        {
            return await _context.students.FirstOrDefaultAsync(s => s.Id == id);
        }
        

        // Método para eliminar un estudiante de la base de datos.
        public async Task<Student> DeleteStudent(int id)
        {
            var existingStudent = await _context.students.FindAsync(id);
            if (existingStudent == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return existingStudent;
        }

        //Metodo para obtener los estudiantes que cumplan en una fecha
        public async Task<IEnumerable<Student>> GetStudentsByBirthDate(DateTime birthDate)
        {
            return await _context.students.Where(s => s.BirthDate == birthDate).ToListAsync();
        }

        // Metodo para obtener listado de matriculas que ha tenido un estudiante
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsOfStudent(int studentId)
        {
            return await _context.enrollments.Where(e => e.StudentId == studentId).ToListAsync();
        }

        
    }
}
