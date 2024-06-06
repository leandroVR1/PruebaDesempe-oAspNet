using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;


namespace PruebaAspNet.Methods
{
    public class PostTeacherMethod
    {
        //Crear profesor
        //PostTeacherMethod.cs
        public static async Task<IActionResult> PostTeacher(Teacher teacher,ITeacherService teacherService)
        {
            var createTeacher = await teacherService.PostTeacher(teacher);
            return new CreatedAtActionResult(nameof(GetTeacherByIdMethod.GetTeacherById), "Teachers", new { id = createTeacher.Id }, createTeacher);
        }

    }
}