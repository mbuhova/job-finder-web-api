using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.WebApi.Extensions
{
    public static class JwtClaimIdentifiers
    {
        public static readonly string Id = "1";

        public static readonly string Rol = "Admin";

        //----- JwtClaims
        public static readonly string ApiAccess = "123";
    }
}
