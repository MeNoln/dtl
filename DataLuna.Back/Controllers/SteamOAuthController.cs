using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataLuna.Back.Controllers
{
    [ApiController]
    [Route("steamAuth")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SteamOAuthController : ControllerBase
    {
        private readonly ILogger<SteamOAuthController> _logger;

        public SteamOAuthController(ILogger<SteamOAuthController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("steamCallback")]
        public async Task<IActionResult> SteamCallbackEndpoint()
        {
            _logger.LogError("LOGGING CLAIMS");
            foreach (var claim in HttpContext.User.Claims)
            {
                _logger.LogError($"{claim.Type} : \n {claim.Value}");
            }
            
            return Ok();
        }
        
        [HttpGet("redirect")]
        public IActionResult RedirectToSteamOAuth()
        {
            return Challenge(new AuthenticationProperties {RedirectUri = "/steamAuth/steamCallback"}, "Steam");
        }
    }
}