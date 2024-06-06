using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Methods;
using PruebaAspNet.Models;


namespace PruebaAspNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase{
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourses(){
            return await GetCoursesMethod.GetAllCourses(_courseService);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            return await GetCourseByIdMethod.GetCourseById(Id, _courseService);
        }

        [HttpPost]
        public async Task<IActionResult> PostCourse(Course course){
            return await PostCourseMethod.PostCourse(course, _courseService);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCourse(int Id, Course course){
            return await PutCourseMethod.PutCourse(Id, course, _courseService);
        }
    
    }
 
}