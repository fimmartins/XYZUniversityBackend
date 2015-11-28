using CourseWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseWebApi.Context
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext()
            : base("Xyz")
        {
        }

        public DbSet<Courses> Courses { get; set; }
    }
}