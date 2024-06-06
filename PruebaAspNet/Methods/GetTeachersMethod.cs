using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;


namespace PruebaAspNet.Methods
{
    public static class GetTeachersMethod
    {
        public static async Task<IActionResult> GetAllTeachers(ITeacherService teacherService)
        {
            return new OkObjectResult(await teacherService.GetAllTeachers());
        }
    }
}
