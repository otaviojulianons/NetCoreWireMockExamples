using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Services;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubController : ControllerBase
    {

        private readonly ILogger<GithubController> _logger;
        private readonly IGithubService _externalService;

        public GithubController(
            ILogger<GithubController> logger,
            IGithubService externalService)
        {
            _logger = logger;
            _externalService = externalService;
        }

        [HttpGet("users/{username}")]
        public async Task<object> GetUser(string username = "otaviojulianons")
        {
            try
            {
                var result = await _externalService.GetUser(username);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
