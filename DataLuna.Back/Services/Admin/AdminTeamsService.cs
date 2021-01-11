using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLuna.Back.Common.Teams;
using DataLuna.Back.Common.Exceptions;
using DataLuna.Back.Domain;
using DataLuna.Back.Domain.Enum;
using DataLuna.Back.Persistence;
using DataLuna.Back.Extensions;
using DataLuna.Back.Infrastructure;
using DataLuna.Back.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DataLuna.Back.Services
{
    public class AdminTeamsService : IAdminTeamsService
    {
        private readonly DataLunaDbContext _dbContext;
        private readonly IYandexStorage _storageService;

        public AdminTeamsService(DataLunaDbContext dbContext, IYandexStorage storageService)
            => (_dbContext, _storageService) = (dbContext, storageService);
        
        public async Task<GetAllTeamsResponse> GetAllTeams()
        {
            var teams = await _dbContext.Teams.AsNoTracking()
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

        public async Task<TeamDto> GetTeamById(long id)
        {
            var team = await _dbContext.Teams.AsNoTracking()
                .Include(i => i.Players)
                .FirstOrDefaultAsync(f => f.Id == id);

            return new TeamDto
            {
                Name = team.Name,
                ImagePath = team.ImagePath,
                Players = new TeamPlayersDto
                {
                    Igl = team.Players.FirstOrDefault(f => f.Role == PlayerRole.Igl)?.NickName,
                    Lurk = team.Players.FirstOrDefault(f => f.Role == PlayerRole.Lurk)?.NickName,
                    Support = team.Players.FirstOrDefault(f => f.Role == PlayerRole.Support)?.NickName,
                    Sniper = team.Players.FirstOrDefault(f => f.Role == PlayerRole.Sniper)?.NickName,
                    Entry = team.Players.FirstOrDefault(f => f.Role == PlayerRole.Entry)?.NickName,
                }
            };
        }

        public Task CreateTeam(CreateTeamCommand command)
        {
            var team = new Team
            {
                Name = command.Name,
            };

            _dbContext.Teams.Add(team);

            return _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeam(UpdateTeamFiledCommand command)
        {
            var team = await GetDomainTeam(command.Id);

            DomainEntityExtensions.UpdateEntityPropValue(command.Param, command.Value, ref team);

            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UploadTeamImage(long teamId, IFormFile image)
        {
            var team = await GetDomainTeam(teamId);

            string cloudImagePath = await _storageService.UploadPlayerImageToCloud(image, FolderPathEnum.Team);
            team.ImagePath = cloudImagePath;

            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTeam(DeleteTeamCommand command)
        {
            var team = await GetDomainTeam(command.Id);

            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Team> GetDomainTeam(long id)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(i => i.Id == id);
            if (team == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);

            return team;
        }
    }
}