using System.Linq;
using System.Threading.Tasks;
using DataLuna.Back.Common.Players;
using DataLuna.Back.Domain;
using DataLuna.Back.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLuna.Back.Services
{
    public class AdminPlayerService : IAdminPlayerService
    {
        private readonly DataLunaDbContext _dbContext;

        public AdminPlayerService(DataLunaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<GetAllPlayersResponse> GetPlayers()
        {
            var players = await _dbContext.Players
                .Include(i => i.Team)
                .Select(s => new PlayerDto
                {
                    Id = s.Id,
                    Team = s.Team.Name,
                    NickName = s.NickName,
                    Name = s.Name,
                    Lastname = s.Surname,
                    ImagePath = s.ImagePath,
                })
                .ToArrayAsync();
            
            return new GetAllPlayersResponse
            {
                Players = players,
            };
        }

        public Task<PlayerDto> GetPlayer(long id)
            => _dbContext.Players
                .Include(i => i.Team)
                .Select(s => new PlayerDto
                {
                    Id = s.Id,
                    Team = s.Team.Name,
                    NickName = s.NickName,
                    Name = s.Name,
                    Lastname = s.Surname,
                    Country = "stub",
                    ImagePath = s.ImagePath,
                })
                .FirstOrDefaultAsync(f => f.Id == id);

        public Task CreatePlayer(CreatePlayerCommand command)
        {
            var player = new Player
            {
                TeamId = command.TeamId,
                NickName = command.NickName,
                Surname = command.Surname,
                Name = command.Name,
            };

            _dbContext.Add(player);

            return _dbContext.SaveChangesAsync();
        }
    }
}