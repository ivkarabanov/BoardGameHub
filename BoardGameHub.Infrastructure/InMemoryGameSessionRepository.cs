using BoardGameHub.Application.Abstractions;
using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Infrastructure
{
    public class InMemoryGameSessionRepository : IGameSessionRepository
    {
        private static int _nextKey = 1;
        private static Dictionary<int, GameSession> _sessions = new();

        public async Task<GameSession> AddAsync(GameSession gameSession)
        {
            if (gameSession == null)
            {
                throw new ArgumentNullException(nameof(gameSession));
            }

            var gameSessionWithId = GameSession.CreateWithId(_nextKey, gameSession);
            _sessions[_nextKey] = gameSessionWithId;

            return gameSessionWithId;
        }

        public async Task<GameSession?> GetAsync(int id)
        {
            var sessionFound = _sessions.TryGetValue(id, out var session);

            return session;
        }

        public async Task<List<GameSession>> ListAsync()
        {
            return _sessions.Values.ToList();
        }
    }
}
