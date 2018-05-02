using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.WebApi.Extensions
{
    public static class JwtClaimIdentifiers
    {
        public static readonly string Id = "UserId";
        
        public static readonly string Role = "Role";
    }
}
