using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BrockAllen.MembershipReboot;

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
        public UserAccount UserAccount { get; set; }
    }
}