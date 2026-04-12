using BoardGameHub.Application.Abstractions;
using BoardGameHub.Domain;
using BoardGameHub.Infrastructure.Abstractions;

namespace BoardGameHub.Application
{
    public class BoardGameService: IBoardGameService
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

        public async Task<BoardGame> AddAsync(BoardGame boardGame) 
        {
            return await _boardGameRepository.AddAsync(boardGame);
        }
    }
}
