using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
             {   new Client 
                {
                    ClientId = "tripgalleryimplicit",
                    ClientName = "Trip Gallery (Implicit)",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>()
                    {
                        "openid", "profile", "gallerymanagement", "roles"
                    },

                    RequireConsent = false,
                    AccessTokenLifetime = 120,

                    // redirect = URI of the Angular application
                    RedirectUris = new List<string>
                    { 
                        "https://localhost:44316/callback.html",      
                        "https://localhost:44316/silentrefreshframe.html"                  
                    }
                }
             };
        }
    }
}