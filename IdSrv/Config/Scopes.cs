using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace IdSrv.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type = ScopeType.Identity,
                    IncludeAllClaimsForUser = true
                },
                new Scope
                {
                    Enabled = true,
                    Name = "webApi",
                    Description = "Access Web Api",
                    Type = ScopeType.Resource,
                    IncludeAllClaimsForUser = true,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.Name),
                        new ScopeClaim(Constants.ClaimTypes.Role)
                    }
                }
               
            };

            scopes.AddRange(StandardScopes.All);
            return scopes;

        }
    }
}