using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    public class AdminPlayerController : ControllerBase
    {
        private readonly IAdminPlayerService _playerService;
        public AdminPlayerController(IAdminPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _playerService.GetPlayers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute]long id)
        {
            return Ok(await _playerService.GetPlayer(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody]CreatePlayerCommand command)
        {
            await _playerService.CreatePlayer(command);
            return Ok();
        }
    }
}