using BrockAllen.MembershipReboot;
using StudentWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApi.App_Start
{
    public class MembershipRebootConfig
    {
        public static MembershipRebootConfiguration<CustomUserAccount> Create()
        {
            var settings = SecuritySettings.Instance;

            var config = new MembershipRebootConfiguration<CustomUserAccount>(settings);

            return config;
        }
    }
}