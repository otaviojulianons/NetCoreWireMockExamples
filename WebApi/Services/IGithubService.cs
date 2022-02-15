using Newtonsoft.Json;
using Refit;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IGithubService
    {
        [Get("/users/{username}")]
        Task<object> GetUser(string username);
    }
}
