using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdSrv.Config
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "XYZ Website",
                    Enabled = true,
 
                    ClientId = "xyzweb",
                    ClientSecrets = new List<Secret>
                    { 
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.Address,
                        Constants.StandardScopes.AllClaims,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.OfflineAccess,
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Phone,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Roles,
                        "webApi"
                    },
 
                    ClientUri = "http://localhost:10071/",
 
                    RequireConsent = true,
                    AllowRememberConsent = true,
 
                    RedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                        "http://localhost:2671/"
                    },
 
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                        "http://localhost:2671/"
                    },
 
                    IdentityTokenLifetime = 360,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}