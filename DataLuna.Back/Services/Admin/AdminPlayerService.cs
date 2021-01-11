using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Domain;
using DataLuna.Back.Infrastructure;
using DataLuna.Back.Infrastructure.Internal;
using DataLuna.Back.Persistence;
using DataLuna.Back.Common.Exceptions;
using DataLuna.Back.Extensions;
using AspNetCore.Yandex.ObjectStorage;

namespace DataLuna.Back.Services
{
    public class AdminPlayerService : IAdminPlayerService
    {
        private readonly DataLunaDbContext _dbContext;
        private readonly IYandexStorage _storageService;

        public AdminPlayerService(DataLunaDbContext dbContext, IYandexStorage storageService)
            => (_dbContext, _storageService) = (dbContext, storageService);
        
        public async Task<GetAllPlayersResponse> GetPlayers()
        {
            var players = await _dbContext.Players.AsNoTracking()
                .Include(i => i.Team)
                .Select(s => new PlayerDto
                {
                    Id = s.Id,
                    Team = s.Team.Name,
                    NickName = s.NickName,
                    Name = s.Name,
                    Lastname = s.Lastname,
                    ImagePath = s.ImagePath,
                })
                .ToArrayAsync();
            
            return new GetAllPlayersResponse
            {
                Players = players,
            };
        }

        public Task<PlayerDto> GetPlayer(long id)
            => _dbContext.Players.AsNoTracking()
                .Include(i => i.Team)
                .Where(w => w.Id == id)
                .Select(s => new PlayerDto
                {
                    Id = s.Id,
                    Team = s.Team.Name,
                    NickName = s.NickName,
                    SteamId = s.SteamId,
                    Name = s.Name,
                    Lastname = s.Lastname,
                    Country = "stub",
                    ImagePath = s.ImagePath,
                })
                .FirstOrDefaultAsync();

        public Task CreatePlayer(CreatePlayerCommand command)
        {
            var player = new Player
            {
                TeamId = command.TeamId,
                NickName = command.NickName,
                SteamId = command.SteamId,
                Lastname = command.Lastname,
                Name = command.Name,
                Role = command.Role,
            };

            _dbContext.Add(player);

            return _dbContext.SaveChangesAsync();
        }

        public async Task UploadPlayerImage(long playerId, IFormFile image)
        {
            var player = await GetDomainPlayer(playerId);

            string cloudImagePath = await _storageService.UploadPlayerImageToCloud(image, FolderPathEnum.Player);
            player.ImagePath = cloudImagePath;

            _dbContext.Players.Update(player);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePlayer(UpdatePlayerFieldCommand command)
        {
            var player = await GetDomainPlayer(command.Id);

            DomainEntityExtensions.UpdateEntityPropValue(command.Param, command.Value, ref player);

            _dbContext.Players.Update(player);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePlayer(DeletePlayerCommand command)
        {
            var player = await GetDomainPlayer(command.Id);

            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Player> GetDomainPlayer(long id)
        {
            var player = await _dbContext.Players.FirstOrDefaultAsync(i => i.Id == id);
            if (player == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);

            return player;
        }
    }
}