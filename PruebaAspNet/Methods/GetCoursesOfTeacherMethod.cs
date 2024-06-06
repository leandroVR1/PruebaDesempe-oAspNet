using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;



namespace PruebaAspNet.Methods
{
    public class GetCoursesOfTeacherMethod
    {
        public static async Task<IActionResult> GetCoursesOfTeacher(int teacherId, ITeacherService teacherService)
        {
            return new OkObjectResult(await teacherService.GetCoursesOfTeacher(teacherId));
        }
        
    }
}