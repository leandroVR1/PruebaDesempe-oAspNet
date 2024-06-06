using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Methods;
using PruebaAspNet.Models;

namespace PruebaAspNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase{
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers(){
            return await GetTeachersMethod.GetAllTeachers(_teacherService);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTeacherById(int Id)
        {
            return await GetTeacherByIdMethod.GetTeacherById(Id, _teacherService);
        }

        [HttpPost]
        public async Task<IActionResult> PostTeacher(Teacher teacher)
        {
            return await PostTeacherMethod.PostTeacher(teacher, _teacherService);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutTeacher(int Id, Teacher teacher)
        {
            return await PutTeacherMethod.PutTeacher(Id, teacher, _teacherService);
        }

        [HttpGet("{teacherId}/courses")]
        public async Task<IActionResult> GetCoursesOfTeacher(int teacherId)
        {
            return await GetCoursesOfTeacherMethod.GetCoursesOfTeacher(teacherId, _teacherService);
        }
        
    }

  
}