using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TripGallery.API.Helpers
{
    public static class TokenIdentityHelper
    {
        public static string GetOwnerIdFromToken()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

            if (identity == null)
                return null;

            var issuerFromIdentity = identity.FindFirst("iss"); 
            var subFromIdentity = identity.FindFirst("sub");

            if (issuerFromIdentity == null || subFromIdentity == null)
                return null;

            return issuerFromIdentity.Value + subFromIdentity.Value;
        }
    }
}
