using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;


namespace PruebaAspNet.Methods
{
    public class GetEnrollmentsMethod
    {
        public static async Task<IActionResult> GetAllEnrollments(IEnrollmentService enrollmentService)
        {
            return new OkObjectResult(await enrollmentService.GetAllEnrollments());
        }
        
    }
}