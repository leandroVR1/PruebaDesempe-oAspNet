using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PutStudentMethod
    {
        //Actualizar estudiante
        //PutStudentMethod.cs
        public static async Task<IActionResult> PutStudent(int Id,Student student,IStudentService studentService)
        {
            var updateStudent = await studentService.PutStudent(Id,student);
            if (updateStudent == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(updateStudent);
        }
        
    }
}