using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Application.Abstractions
{
    public interface IGameSessionRepository
    {
        Task<GameSession> AddAsync(GameSession gameSession);
        Task<GameSession?> GetAsync(int id);
        Task<List<GameSession>> ListAsync();
    }
}
