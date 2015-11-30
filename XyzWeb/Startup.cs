using IdentityServer3.Core;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;

[assembly: OwinStartup(typeof(XyzWeb.Startup))]

namespace XyzWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "xyzweb",
                Authority = "https://localhost:44333/core/",
                RedirectUri = "http://localhost:10071/",
                ResponseType = "id_token token",
                Scope = "openid profile roles webApi",

                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = async n =>
                    {
                        var identity = n.AuthenticationTicket.Identity;
                        var token = n.ProtocolMessage.AccessToken;
                        var roles = identity.FindAll("role");

                        // persist access token in cookie
                        if (!string.IsNullOrEmpty(token))
                        {
                            n.AuthenticationTicket.Identity.AddClaim(
                                new Claim("access_token", token));
                            n.AuthenticationTicket.Identity.AddClaims(roles);
                            
                        }
                    }
                }
            });
        }
    }
}