using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNet.Interfaces;

namespace PruebaAspNet.Methods
{
    public static class GetStudentsMethod
    {
        public static async Task<IActionResult> GetAllStudents(IStudentService studentService)
        {
            return new OkObjectResult(await studentService.GetAllStudents());
        }
    }
}
