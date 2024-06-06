using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PostCourseMethod
    {
       //Crer curso
       //PostCourseMethod.cs
       public static async Task<IActionResult> PostCourse(Course course,ICourseService courseService)
       {
      
            var createCourse = await courseService.PostCourse(course);
            return new CreatedAtActionResult(nameof(GetCourseByIdMethod.GetCourseById), "Courses", new { id = createCourse.Id }, createCourse);
        
       
       }



    }
    
    
}