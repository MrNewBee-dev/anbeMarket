using Anbe.Areas.Identity.Data;
using System.Threading.Tasks;


namespace Anbe.Areas.API.Service
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(ApplicationUser User);
    }
}
