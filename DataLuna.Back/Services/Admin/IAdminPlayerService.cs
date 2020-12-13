using System.Threading.Tasks;
using DataLuna.Back.Common.Players;

namespace DataLuna.Back.Services
{
    public interface IAdminPlayerService
    {
        Task<GetAllPlayersResponse> GetPlayers();
        Task<PlayerDto> GetPlayer(long id);
        Task CreatePlayer(CreatePlayerCommand command);
    }
}