using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;

namespace PruebaAspNet.Methods
{
    public class GetStudentsByBirthDateMethod
    {
        public static async Task<IActionResult> GetStudentsByBirthDate(IStudentService studentService, DateTime birthDate)
        {
            return new OkObjectResult(await studentService.GetStudentsByBirthDate(birthDate));
        }
    
        
    }
}