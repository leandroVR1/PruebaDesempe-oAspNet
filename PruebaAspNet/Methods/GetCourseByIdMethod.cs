
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;



namespace PruebaAspNet.Methods
{
    public class GetCourseByIdMethod
    {
        public static async Task<IActionResult> GetCourseById(int Id, ICourseService courseService)
        {
            
                var course = await courseService.GetCourseById(Id);
                if (course == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(course);
            
          
        }
        
    }
}