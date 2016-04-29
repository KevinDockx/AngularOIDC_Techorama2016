using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace TripCompany.IdentityServer.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>() {                 
                new InMemoryUser
	            {
	                Username = "Kevin",
	                Password = "secret",                    
	                Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf",
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Kevin"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Dockx"),
                        new Claim("role", "PayingUser")
                    }
	             }
	            ,
	            new InMemoryUser
	            {
	                Username = "Sven",
	                Password = "secret",
	                Subject = "bb61e881-3a49-42a7-8b62-c13dbe102018",
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Sven"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Vercauteren"),
                        new Claim("role", "FreeUser")
                    }
	            }  
            };
        }
    }

}
