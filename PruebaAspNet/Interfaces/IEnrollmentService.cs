using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaAspNet.Models;

namespace PruebaAspNet.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollmentById(int Id);
        Task<Enrollment> PostEnrollment(Enrollment enrollment);
        Task<Enrollment> PutEnrollment(int Id, Enrollment enrollment);
        

        
    }
}