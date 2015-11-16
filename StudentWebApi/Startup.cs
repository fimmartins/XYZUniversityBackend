using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(StudentWebApi.Startup))]

namespace StudentWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            #region authentication part

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new[] { "implicit" }
            });

            #endregion

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            app.UseWebApi(config);
        }
    }
}