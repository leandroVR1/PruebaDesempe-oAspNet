using Microsoft.EntityFrameworkCore;
using PruebaAspNet.Models;

namespace PruebaAspNet.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext (DbContextOptions<BaseContext> options)
            : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        


         // Configuración de mapeo para el Enum StatusEnum en la tabla enrollments
             modelBuilder.Entity<Enrollment>()
                .Property(m => m.Status)
                .HasConversion<string>();
            // Configuración de mapeo para el Enum StatusEnum para las tablas
            
      

        // Configuración de la relación  Un alumno puede estar matriculado en uno o más cursos
        modelBuilder.Entity<Student>()
               .HasMany(s => s.enrollments)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentId);

        // Configuracion de la relacion Un curso puede tener uno o más alumnos matriculados
        modelBuilder.Entity<Course>()
               .HasMany(c => c.enrollments)
               .WithOne(e => e.Course)
               .HasForeignKey(e => e.CourseId);
        // Configuración de la relación Un curso está a cargo de un único profesor
        modelBuilder.Entity<Course>()
        .HasOne(c => c.Teacher)
        .WithMany(t => t.courses)
        .HasForeignKey(c => c.TeacherId);

        // Configuracion de la relacion Una matrícula está asociada a un alumno y a un curso específico.
        modelBuilder.Entity<Enrollment>()
               .HasOne(e => e.Student)
               .WithMany(s => s.enrollments)
               .HasForeignKey(e => e.StudentId);

              

        
       
       
            
            
        }

    }



}
    
