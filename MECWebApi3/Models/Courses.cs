using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MECWebApi.Models
{
    public class MECCourses
    {
        [Key]
        public Int32 CourseId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Institute { get; set; }
    }
}