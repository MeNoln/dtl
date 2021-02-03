using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataLuna.Back.Controllers
{
    [ApiController]
    [Route("steamAuth")]
    public class ClientEventController : ControllerBase
    {

        public ClientEventController()
        {

        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok();
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute]int id)
        {
            return Ok();
        }
    }
}