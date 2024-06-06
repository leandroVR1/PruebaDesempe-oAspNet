using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;

namespace PruebaAspNet.Methods
{
    public class GetEnrollmentByIdMethod
    {
        public static async Task<IActionResult> GetEnrollmentById(int Id, IEnrollmentService enrollmentService)
        {

                var enrollment = await enrollmentService.GetEnrollmentById(Id);
                if (enrollment == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(enrollment);
        }
        
    }
}