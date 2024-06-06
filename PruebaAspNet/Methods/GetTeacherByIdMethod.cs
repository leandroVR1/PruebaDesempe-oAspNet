using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;


namespace PruebaAspNet.Methods
{
    public class GetTeacherByIdMethod
    {
        public static async Task<IActionResult> GetTeacherById(int Id, ITeacherService teacherService)
        {

                var teacher = await teacherService.GetTeacherById(Id);
                if (teacher == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(teacher);
        }
        
    }
}