using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PutEnrollmentMethod
    {
        //Actualizar matricula
        //PutEnrollmentMethod.cs
        public static async Task<IActionResult> PutEnrollment(int Id,Enrollment enrollment,IEnrollmentService enrollmentService)
        {
            var updateEnrollment = await enrollmentService.PutEnrollment(Id,enrollment);
            if (updateEnrollment == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(updateEnrollment);
        }
        
    }
}