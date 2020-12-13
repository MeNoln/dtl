using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;

namespace DataLuna.Back.Services
{
    public interface IAdminTeamsService
    {
        Task<GetAllTeamsResponse> GetAllTeams();
        Task<TeamDto> GetTeamById(long id);
        Task CreateTeam(CreateTeamCommand command);
    }
}