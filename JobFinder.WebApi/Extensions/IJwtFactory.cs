using System.Security.Claims;
using System.Threading.Tasks;

namespace JobFinder.WebApi.Extensions
{
    public interface IJwtFactory
    {
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, string role);

        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
    }
}