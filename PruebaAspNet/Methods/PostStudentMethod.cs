using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Models;

namespace PruebaAspNet.Methods
{
    public class PostStudentMethod
    {
        //Crear estudiante
        //PostStudentMethod.cs
        public static async Task<IActionResult> PostStudent(Student student,IStudentService studentService)
        {
            var createStudent = await studentService.PostStudent(student);
            return new CreatedAtActionResult(nameof(GetStudentByIdMethod.GetStudentById), "Students", new { id = createStudent.Id }, createStudent);
        }
        
    }
}