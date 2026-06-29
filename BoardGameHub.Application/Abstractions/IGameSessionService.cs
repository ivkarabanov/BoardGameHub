using BoardGameHub.API.DTO;
using BoardGameHub.Application.Models;
using BoardGameHub.Application.Models.DTO;

namespace BoardGameHub.Application.Abstractions
{
    public interface IGameSessionService
    {
        Task<GameSessionListResponse> ListAsync();

        Task<GameSessionResponse> CreateAsync(CreateGameSessionModel gameSessionModel);

        Task<GameSessionResponse> GetAsync(int id);
    }
}
