using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PruebaAspNet.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }      

        [JsonIgnore]
        public ICollection<Enrollment>? enrollments { get; set; }

       
       
    }
}