using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;
using DataLuna.Back.Common.Attributes;
using DataLuna.Back.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    [AdminAuthorize]
    public class AdminTeamController : ControllerBase
    {
        private readonly IAdminTeamsService _teamsService;
        public AdminTeamController(IAdminTeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            return Ok(await _teamsService.GetAllTeams());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute]long id)
        {
            return Ok(await _teamsService.GetTeamById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody]CreateTeamCommand command)
        {
            await _teamsService.CreateTeam(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody]UpdateTeamFiledCommand command)
        {
            await _teamsService.UpdateTeam(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UploadImage([FromRoute]long id, [FromForm]IFormFile image)
        {
            await _teamsService.UploadTeamImage(id, image);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute]long id)
        {
            await _teamsService.DeleteTeam(new DeleteTeamCommand { Id = id });
            return Ok();
        }
    }
}