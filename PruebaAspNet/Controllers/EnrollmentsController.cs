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
    public class EnrollmentsController : ControllerBase{
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEnrollments(){
            return await GetEnrollmentsMethod.GetAllEnrollments(_enrollmentService);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEnrollmentById(int Id)
        {
            return await GetEnrollmentByIdMethod.GetEnrollmentById(Id, _enrollmentService);
        }
        [HttpPost]
        public async Task<IActionResult> PostEnrollment(Enrollment enrollment){
            return await PostEnrollmentMethod.PostEnrollment(enrollment, _enrollmentService);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutEnrollment(int Id, Enrollment enrollment){
            return await PutEnrollmentMethod.PutEnrollment(Id, enrollment, _enrollmentService);
        }
        
    }
    
}