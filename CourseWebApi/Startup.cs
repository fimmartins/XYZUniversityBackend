using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using System.IdentityModel.Tokens;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(CourseWebApi.Startup))]

namespace CourseWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new[] { "webApi" }
            });

            var config = new HttpConfiguration();
            app.UseWebApi(config);
        }
    }
}