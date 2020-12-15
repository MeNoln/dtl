using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Services;
using DataLuna.Back.Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    [AdminAuthorize]
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

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody]UpdatePlayerFieldCommand command)
        {
            await _playerService.UpdatePlayer(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UploadImage([FromRoute]long id, [FromForm]IFormFile image)
        {
            await _playerService.UploadPlayerImage(id, image);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute]long id)
        {
            await _playerService.DeletePlayer(new DeletePlayerCommand { Id = id });
            return Ok();
        }
    }
}