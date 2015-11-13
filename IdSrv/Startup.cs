using Owin;
using IdSrv.Config;
using IdentityServer3.Core.Configuration;

namespace IdSrv
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Identity Server",
                    IssuerUri = "https://idsrv3/mixit",
                    SigningCertificate = Certificate.Get(),
                    Factory = Factory.Configure("MyIdentityDb"),
                });
            });

        }
    }
}