using BoardGameHub.API.DTO;
using BoardGameHub.Application.Models;

namespace BoardGameHub.Application.Abstractions
{
    public interface IGameSessionService
    {
        Task<GameSessionListResponse> ListAsync();

        Task<GameSessionResponse> CreateAsync(CreateGameSessionRequest gameSessionModel);

        Task<GameSessionResponse> GetAsync(int id);
    }
}
