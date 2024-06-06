using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;

namespace PruebaAspNet.Methods
{
    public class GetCoursesMethod
    {
        public static async Task<IActionResult> GetAllCourses(ICourseService courseService)
        {
            return new OkObjectResult(await courseService.GetAllCourses());
        }
        
    }
}