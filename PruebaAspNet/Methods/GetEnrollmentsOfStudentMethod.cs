using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;


namespace PruebaAspNet.Methods
{
    public class GetEnrollmentsOfStudentMethod
    {
        public static async Task<IActionResult> GetEnrollmentsOfStudent(int studentId, IStudentService studentService)
        {
            return new OkObjectResult(await studentService.GetEnrollmentsOfStudent(studentId));
        }
        
    }
}