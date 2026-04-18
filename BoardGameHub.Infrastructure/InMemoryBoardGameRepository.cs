using BoardGameHub.Domain;
using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Application.Abstractions;

namespace BoardGameHub.Infrastructure
{
    public class InMemoryBoardGameRepository: IBoardGameRepository
    {
        private static int _nextKey = 1;
        private static Dictionary<int, BoardGame> _games = new();

        public async Task<BoardGame> AddAsync(BoardGame gameWithoutId)
        {
            if (_games.Any(x=>x.Value.Title == gameWithoutId.Title))
            {
                throw new GameAlreadyExistsException("Игра с таким названием уже добавлена");
            }
                        
            var game = gameWithoutId.AssignId(_nextKey);
            _games.Add(gameWithoutId.Id, game);

            _nextKey++;

            return game;
        }

        public async Task<BoardGame> GetAsync(int id)
        {
            if (!_games.ContainsKey(id))
            {
                throw new GameNotFoundException($"Настольная игра с идентификатором {id} не найдена");
            }

            var game = _games[id];
            return game;
        }

        public async Task<List<BoardGame>> ListAsync()
        {
            return _games.Values.ToList();
        }
    }
}
