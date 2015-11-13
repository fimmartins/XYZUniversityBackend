using System.Data.Entity;

namespace StudentWebApi.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=MyIdentityDb")
        {
        }

        public System.Data.Entity.DbSet<StudentWebApi.Models.Student> Students { get; set; }
    }
}