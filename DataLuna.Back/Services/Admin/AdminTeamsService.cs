using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;
using DataLuna.Back.Domain;
using DataLuna.Back.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLuna.Back.Services
{
    public class AdminTeamsService : IAdminTeamsService
    {
        private readonly DataLunaDbContext _dbContext;

        public AdminTeamsService(DataLunaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<GetAllTeamsResponse> GetAllTeams()
        {
            var teams = await _dbContext.Teams
                .Select(s => new TeamDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImagePath = s.ImagePath,
                })
                .ToArrayAsync();
            
            return new GetAllTeamsResponse
            {
                Teams = teams,
            };
        }

        public Task<TeamDto> GetTeamById(long id)
            => _dbContext.Teams
                .Include(i => i.Players)
                .Select(s => new TeamDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImagePath = s.ImagePath,
                    Players = s.Players.Select(ss => new TeamPlayerDto
                    {
                        NickName = ss.NickName,
                    }).ToArray()
                })
                .FirstOrDefaultAsync(f => f.Id == id);

        public Task CreateTeam(CreateTeamCommand command)
        {
            var team = new Team
            {
                Name = command.Name,
            };

            _dbContext.Teams.Add(team);

            return _dbContext.SaveChangesAsync();
        }
    }
}