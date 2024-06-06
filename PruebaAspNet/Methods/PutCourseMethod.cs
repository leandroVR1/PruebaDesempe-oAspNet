using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PutCourseMethod
    {
        //Actualizar curso
        //PutCourseMethod.cs
        public static async Task<IActionResult> PutCourse(int Id,Course course,ICourseService courseService)
        {
            var updateCourse = await courseService.PutCourse(Id,course);
            if (updateCourse == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(updateCourse);
            
        }
        
    }
}