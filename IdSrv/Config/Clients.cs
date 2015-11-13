using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Clients
/// </summary>
namespace IdSrv.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]{
                new Client
                {
                    ClientName = "AlunoWebApi",
                    Enabled = true,

                    ClientId = "AlunoWebApi",
                    ClientSecrets = new List<Secret>{ new Secret("senhaDoCliente".Sha256())},
                    Flow = Flows.Implicit,
                    
                    ClientUri = "http://www.resExplorer.com",
                
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    
                    RedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                    },
                    
                    IdentityTokenLifetime = 360,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}