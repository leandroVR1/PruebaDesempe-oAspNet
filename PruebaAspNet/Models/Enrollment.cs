using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;


namespace PruebaAspNet.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime? Date { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnum Status { get; set; }


    

        
    }
}

