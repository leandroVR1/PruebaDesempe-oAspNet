using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PostEnrollmentMethod
    {
        public static async Task<IActionResult> PostEnrollment(Enrollment enrollment,IEnrollmentService enrollmentService)
        {
            var createEnrollment = await enrollmentService.PostEnrollment(enrollment);
            return new CreatedAtActionResult(nameof(GetEnrollmentByIdMethod.GetEnrollmentById), "Enrollments", new { id = createEnrollment.Id }, createEnrollment);
        }
        
    }
}