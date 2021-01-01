using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("CodersAcademyBootcamp", "Coders Academy Bootcamp API",new List<string> { "coders-academy-user" })
                {
                    ApiSecrets =
                    {
                        new Secret("CodersAcademyBootcampSecret".Sha256())
                    },
                    Scopes =
                    {
                        "CodersAcademyScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope
                {
                    Name = "CodersAcademyScope",
                    DisplayName = "Scope for Coders Academy Scope",
                    UserClaims = { "coders-academy-bootcamp-user" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "79E0C2E2-D750-45BC-8FA3-1A9D5F9F82B5",
                    ClientName = "Coders Academy API",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("CodersAcademyBootcampSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CodersAcademyScope"
                    },

                }
            };
        }
    }
}
