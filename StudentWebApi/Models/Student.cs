using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Relational;
using StudentWebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using CourseWebApi.Models;

namespace StudentWebApi.Models
{
    public class Student
    {
        [Key]
        public Int32 StudentId { get; set; }
        [Required] 
        public String FirstName { get; set; }
        [Required] 
        public String LastName { get; set; }
        [Required]
        public virtual CustomUserAccount UserAccount { get; set; }
        [Required]
        public virtual Courses Course { get; set; }
    }
}