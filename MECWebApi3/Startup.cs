using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Collections.Generic;

[assembly: OwinStartup("MECWebApiStartup", typeof(MECWebApi.Startup))]

namespace MECWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.UseWebApi(config);
        }
    }
}