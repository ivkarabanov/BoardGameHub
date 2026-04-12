using BoardGameHub.Domain;
using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Infrastructure.Abstractions;

namespace BoardGameHub.Infrastructure
{
    public class InMemoryBoardGameRepository: IBoardGameRepository
    {
        private const int DefaultFirstKey = 1;
        private static Dictionary<int, BoardGame> _games = new();

        public async Task<BoardGame> AddAsync(BoardGame game)
        {
            if (_games.Any(x=>x.Value.Title == game.Title))
            {
                throw new GameAlreadyExistsException("Игра с таким названием уже добавлена");
            }

            var newGameId = _games.Any() ? _games.Keys.Max() + 1 : DefaultFirstKey;
            game.Id = newGameId;
            _games.Add(game.Id, game);

            return game;
        }

        public async Task<List<BoardGame>> ListAsync()
        {
            return _games.Values.ToList();
        }
    }
}
