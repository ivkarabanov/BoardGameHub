using AutoMapper;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain;

namespace BoardGameHub.Application
{
    public sealed class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IMapper _mapper;

        public BoardGameService(IBoardGameRepository boardGameRepository, IMapper mapper)
        {
            _boardGameRepository = boardGameRepository;
            _mapper = mapper;
        }

        public async Task<List<BoardGame>> ListAsync()
        {
            return await _boardGameRepository.ListAsync();
        }

        public async Task<BoardGame> CreateAsync(CreateBoardGameModel boardGameModel)
        {
            var boardGame = _mapper.Map<BoardGame>(boardGameModel);
            return await _boardGameRepository.AddAsync(boardGame);
        }

        public async Task<BoardGame> GetAsync(int id)
        {
            return await _boardGameRepository.GetAsync(id);
        }
    }
}
