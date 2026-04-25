using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Application
{
    public sealed class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public async Task<List<BoardGame>> ListAsync()
        {
            return await _boardGameRepository.ListAsync();
        }

        public async Task<BoardGame> CreateAsync(CreateBoardGameModel boardGameModel)
        {
            var title = new BoardGameTitle(boardGameModel.Title);
            var duration = new Duration(boardGameModel.DurationMinutes);
            var playerCountRange = new PlayerCountRange(boardGameModel.MinPlayersCount, boardGameModel.MaxPlayersCount);

            var boardGame = new BoardGame(title, duration, playerCountRange);

            return await _boardGameRepository.AddAsync(boardGame);
        }

        public async Task<BoardGame> GetAsync(int id)
        {
            return await _boardGameRepository.GetAsync(id);
        }
    }
}
