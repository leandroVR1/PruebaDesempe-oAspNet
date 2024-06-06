using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;


namespace PruebaAspNet.Methods
{
    public class GetStudentByIdMethod{
        public static async Task<IActionResult> GetStudentById(int Id, IStudentService studentService)
        {
            var student = await studentService.GetStudentById(Id);
            if (student == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(student);
        }
    }
   
    
}