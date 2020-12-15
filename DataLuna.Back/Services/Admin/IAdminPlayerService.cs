using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DataLuna.Back.Common.Players;

namespace DataLuna.Back.Services
{
    public interface IAdminPlayerService
    {
        Task<GetAllPlayersResponse> GetPlayers();
        Task<PlayerDto> GetPlayer(long id);
        Task CreatePlayer(CreatePlayerCommand command);
        Task UploadPlayerImage(long playerId, IFormFile image);
        Task UpdatePlayer(UpdatePlayerFieldCommand command);
        Task DeletePlayer(DeletePlayerCommand command);
    }
}