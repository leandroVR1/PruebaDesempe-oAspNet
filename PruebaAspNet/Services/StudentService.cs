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

        









       
/*
         // Método para actualizar un médico en la base de datos.
         public async Task<Medico> UpdateMedico(int Id, Medico medico)
         {
             var existingMedico = await _context.Medicos.FindAsync(Id);
             if (existingMedico == null)
             {
                 return null;
             }

             existingMedico.Nombre = medico.Nombre;
             existingMedico.Correo = medico.Correo;
             existingMedico.Telefono = medico.Telefono;
             existingMedico.EspecialidadId = medico.EspecialidadId;

             await _context.SaveChangesAsync();
             return existingMedico;
         }

        // Método para obtener todos los pacientes asociados a un médico específico.
 public async Task<IEnumerable<Paciente>> GetPacientesDeMedico(int medicoId)
 {
     // Se seleccionan las citas donde el médico es el especificado y el estado es disponible.
     // Luego, se seleccionan los pacientes asociados a esas citas.
     // Se utiliza el método Distinct para eliminar cualquier paciente duplicado.
     // Finalmente, se devuelve la lista de pacientes.
     return await _context.Citas
         // Se seleccionan las citas donde el médico es el especificado y el estado es disponible.
         // Esto se logra con el método Where, que filtra las citas según las condiciones especificadas.
        .Where(c => c.MedicoId == medicoId && c.Estado == EstadoEnum.Disponible)
        .Select(c => c.Paciente)
        .Distinct()
        .ToListAsync();
 }

  //Metodo para obtener citas asociadas a un medico en especifico
  public async Task<IEnumerable<Cita>> GetCitasDeMedico(int medicoId)
  {
      // Se seleccionan las citas donde el médico es el especificado y el estado es disponible.
      // Luego, se seleccionan los pacientes asociados a esas citas.
      // Se utiliza el método Distinct para eliminar cualquier paciente duplicado.
      // Finalmente, se devuelve la lista de pacientes.
      return await _context.Citas
          // Se seleccionan las citas donde el médico es el especificado y el estado es disponible.
          // Esto se logra con el método Where, que filtra las citas según las condiciones especificadas.
         .Where(c => c.MedicoId == medicoId && c.Estado == EstadoEnum.Disponible)
         .ToListAsync();
  }

 */





 /*
System.InvalidOperationException: Cannot convert string value 'pagada' from the database to any value in the mapped 'StatusEnum' enum.
   at Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal.StringEnumConverter`3.ConvertToEnum(String value)
   at lambda_method14(Closure, QueryContext, DbDataReader, ResultContext, SingleQueryResultCoordinator)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at PruebaAspNet.Services.StudentService.GetEnrollmentsOfStudent(Int32 studentId) in /home/riwip5-028/Documents/leo/Simulacro1Asp.Net/PruebaDesempe-oAspNet/PruebaAspNet/Services/StudentService.cs:line 85
   at PruebaAspNet.Methods.GetEnrollmentsOfStudentMethod.GetEnrollmentsOfStudent(Int32 studentId, IStudentService studentService) in /home/riwip5-028/Documents/leo/Simulacro1Asp.Net/PruebaDesempe-oAspNet/PruebaAspNet/Methods/GetEnrollmentsOfStudentMethod.cs:line 15
   at PruebaAspNet.Controllers.StudentsController.GetEnrollmentsOfStudent(Int32 studentId) in /home/riwip5-028/Documents/leo/Simulacro1Asp.Net/PruebaDesempe-oAspNet/PruebaAspNet/Controllers/StudentsController.cs:line 47
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeInnerFilterAsync>g__Awaited|13_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

HEADERS
=======
Accept: 
Connection: keep-alive
Host: localhost:5236
User-Agent: Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36
Accept-Encoding: gzip, deflate, br
Accept-Language: en-US,en;q=0.9,es;q=0.8
Referer: http://localhost:5236/index.html
sec-ch-ua: "Google Chrome";v="117", "Not;A=Brand";v="8", "Chromium";v="117"
sec-ch-ua-mobile: ?0
sec-ch-ua-platform: "Linux"
Sec-Fetch-Site: same-origin
Sec-Fetch-Mode: cors
Sec-Fetch-Dest: empty
 
 
 */
    }
}
