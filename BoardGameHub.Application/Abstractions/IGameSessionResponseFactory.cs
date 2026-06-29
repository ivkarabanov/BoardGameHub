using BoardGameHub.Application.Models;
using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Application.Abstractions
{
    public interface IGameSessionResponseFactory
    {
        GameSessionResponse Create(GameSession gameSession, BoardGame boardGame);
    }
}
