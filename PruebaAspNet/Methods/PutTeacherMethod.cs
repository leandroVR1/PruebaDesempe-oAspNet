using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PutTeacherMethod
    {
        //Actualizar un campo o varios campos de la tabla teachers
        public static async Task<IActionResult> PutTeacher(int Id, Teacher teacher, ITeacherService teacherService)
        {
            var updateTeacher = await teacherService.PutTeacher(Id, teacher);
            if (updateTeacher == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(updateTeacher);
        }
        
    }
}