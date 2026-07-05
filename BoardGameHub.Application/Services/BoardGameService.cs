using AutoMapper;
using BoardGameHub.API.DTO;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Domain.Entitites;
using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Application.Services
{
    public sealed class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IMapper _mapper;

        public BoardGameService(IBoardGameRepository boardGameRepository,
            IMapper mapper)
        {
            _boardGameRepository = boardGameRepository;
            _mapper = mapper;
        }

        public async Task<BoardGameListResponse> ListAsync()
        {
            var games = await _boardGameRepository.ListAsync();
            var gamesDto = _mapper.Map<List<BoardGameResponse>>(games);
            return new BoardGameListResponse() { BoardGames = gamesDto };
        }

        public async Task<BoardGameResponse> CreateAsync(CreateBoardGameRequest boardGameModel)
        {
            var title = new BoardGameTitle(boardGameModel.Title);
            var duration = new Duration(boardGameModel.DurationMinutes);
            var playerCountRange = new PlayerCountRange(boardGameModel.MinPlayersCount, boardGameModel.MaxPlayersCount);

            var boardGame = new BoardGame(title, duration, playerCountRange);

            var storedBoardGame = await _boardGameRepository.AddAsync(boardGame);
            var gameDto = _mapper.Map<BoardGameResponse>(boardGame);
            return gameDto;
        }

        public async Task<BoardGameResponse> GetAsync(int id)
        {
            var boardGame = await _boardGameRepository.GetAsync(id);
            if (boardGame == null) 
            {
                throw new GameNotFoundException($"Не найдена настольная игры с идентификатором: {id}");
            }

            var gameDto = _mapper.Map<BoardGameResponse>(boardGame);

            return gameDto;
        }
    }
}
