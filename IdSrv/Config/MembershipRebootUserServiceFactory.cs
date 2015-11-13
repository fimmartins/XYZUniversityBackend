using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Ef;
using IdentityServer3.Core.Services;
using IdentityServer3.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MembershipRebootUserServiceFactory
/// </summary>
namespace IdSrv.Config
{
    public class MembershipRebootUserServiceFactory
    {
        public static IUserService Factory(string connString)
        {
            var db = new DefaultMembershipRebootDatabase(connString);
            var repo = new DefaultUserAccountRepository(db);
            var userAccountService = new UserAccountService(config, repo);
            var userSvc = new MembershipRebootUserService<UserAccount>(userAccountService);
            return userSvc;
        }

        static MembershipRebootConfiguration config;
        static MembershipRebootUserServiceFactory()
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<DefaultMembershipRebootDatabase, BrockAllen.MembershipReboot.Ef.Migrations.Configuration>());

            config = new MembershipRebootConfiguration();
            config.PasswordHashingIterationCount = 50000;
            config.AllowLoginAfterAccountCreation = true;
            config.RequireAccountVerification = false;
        }
    }
}