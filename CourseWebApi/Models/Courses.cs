using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWebApi.Models
{
    public class Courses
    {
        [Key]
        public Int32 CourseId { get; set; }
        [Required]
        public String Name { get; set; }
    }
}