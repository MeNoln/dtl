using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;
using DataLuna.Back.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DataLuna.Back.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
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
    }
}