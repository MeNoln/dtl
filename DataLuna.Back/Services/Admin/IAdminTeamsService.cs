using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DataLuna.Back.Common.Teams;

namespace DataLuna.Back.Services
{
    public interface IAdminTeamsService
    {
        Task<GetAllTeamsResponse> GetAllTeams();
        Task<TeamDto> GetTeamById(long id);
        Task CreateTeam(CreateTeamCommand command);
        Task UpdateTeam(UpdateTeamFiledCommand command);
        Task UploadTeamImage(long teamId, IFormFile image);
        Task DeleteTeam(DeleteTeamCommand command);
    }
}