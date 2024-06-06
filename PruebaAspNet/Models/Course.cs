using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAspNet.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Schedule { get; set;} 
        public string? Duration { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Enrollment>? enrollments { get; set; }
        
    }
}