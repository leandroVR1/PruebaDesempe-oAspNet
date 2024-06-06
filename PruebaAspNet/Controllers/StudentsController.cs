using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Methods;
using PruebaAspNet.Models;

namespace PruebaAspNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase{
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents(){
            return await GetStudentsMethod.GetAllStudents(_studentService);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentById(int Id){
            return await GetStudentByIdMethod.GetStudentById(Id, _studentService);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student){
            return await PostStudentMethod.PostStudent(student, _studentService);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutStudent(int Id, Student student){
            return await PutStudentMethod.PutStudent(Id, student, _studentService);
        }

    
        [HttpGet("BirthDate/{birthDate}")]
        public async Task<IActionResult> GetStudentsByBirthDate(DateTime birthDate){
            return await GetStudentsByBirthDateMethod.GetStudentsByBirthDate(_studentService, birthDate);
        }
        [HttpGet("{studentId}/enrollments")]
        public async Task<IActionResult> GetEnrollmentsOfStudent(int studentId){
            return await GetEnrollmentsOfStudentMethod.GetEnrollmentsOfStudent(studentId, _studentService);
        }

       

    }
}