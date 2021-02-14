using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataLuna.Back.Services;

namespace DataLuna.Back.Controllers
{
    [ApiController]
    [Route("steamAuth")]
    public class ClientEventController : ControllerBase
    {
        private readonly IClientEventService _clientEvents;

        public ClientEventController(IClientEventService clientEvents)
        {
            _clientEvents = clientEvents;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok();
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute]int id)
        {
            return Ok(await _clientEvents.GetEvent(id));
        }
    }
}