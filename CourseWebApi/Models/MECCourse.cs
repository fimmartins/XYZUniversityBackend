using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWebApi.Models
{
    public class MECCourse
    {
        public Int32 CourseId { get; set; }
        public String Name { get; set; }
        public String Institute { get; set; }
    }
}