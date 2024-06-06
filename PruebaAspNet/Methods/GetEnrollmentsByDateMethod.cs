using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;

namespace PruebaAspNet.Methods
{
    public class GetEnrollmentsByDateMethod
    {
        public static async Task<IActionResult> GetEnrollmentsByDate(DateTime date, IEnrollmentService enrollmentService)
        {
            return new OkObjectResult(await enrollmentService.GetEnrollmentsByDate(date));
        }
        
    }
}