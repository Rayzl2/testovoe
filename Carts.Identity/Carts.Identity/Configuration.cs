using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Carts.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes => 
        new List<ApiScope>
        {
                new ApiScope("CartWebApi", "Web Api")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
              new ApiResource("CartsWebApi", "Web Api", new [] { JwtClaimTypes.Name })
              {
                  Scopes = { "CartWebApi" }
                }
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "carts-webapi",
                ClientName = "Carts Web",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("verysecret".Sha256()) },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "CartWebApi"
                }
            }

        };
    }
}
