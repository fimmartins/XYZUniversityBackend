using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentWebApi.Entities;
using StudentWebApi.Models;

namespace StudentWebApi.Context
{
    public class CustomDb : MembershipRebootDbContext<CustomUserAccount>
    {
        public CustomDb()
            : base("MyIdentityDb")
        {
        }

        public System.Data.Entity.DbSet<Student> Students { get; set; }
    }

    public class CustomUserAccountRepository : DbContextUserAccountRepository<CustomDb, CustomUserAccount>
    {
        public CustomUserAccountRepository(CustomDb db)
            : base(db)
        {
        }
    }
}