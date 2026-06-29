using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Exceptions;
using BoardGameHub.Application.Models;
using BoardGameHub.Application.Models.DTO;
using BoardGameHub.Domain.Entitites;
using BoardGameHub.Domain.Exceptions;

namespace BoardGameHub.Application.Services
{
    public class GameSessionService : IGameSessionService
    {
        private readonly IGameSessionRepository _sessionRepository;
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IGameSessionResponseFactory _responseFactory;

        public GameSessionService(IGameSessionRepository sessionRepository,
            IBoardGameRepository boardGameRepository,
            IGameSessionResponseFactory responseFactory)
        {
            _sessionRepository = sessionRepository;
            _boardGameRepository = boardGameRepository;
            _responseFactory = responseFactory;
        }

        public async Task<GameSessionResponse> CreateAsync(CreateGameSessionModel gameSessionModel)
        {
            var boardGame = await _boardGameRepository.GetAsync(gameSessionModel.BoardGameId);

            if (boardGame == null)
            { 
                    throw new GameNotFoundException($"Не удалось создать игровую сессию, так как не найдена настольная игра" +
                        $" (id: {gameSessionModel.BoardGameId}) для игровой сессии: {gameSessionModel.Name}");
            }

            var notStoredSessionWithouId = GameSession.CreateNew(
                gameSessionModel.BoardGameId,
                gameSessionModel.Name,
                gameSessionModel.ScheduledAt);

            var storedSession = await _sessionRepository.AddAsync(notStoredSessionWithouId);
            var storedSessionGame = await _boardGameRepository.GetAsync(storedSession.Id);
            if (storedSessionGame == null)
            {
                throw new GameNotFoundException($"После сохранения игровой сессии не удалось найти настольную игру" +
                    $" (id: {storedSession.BoardGameId}) для игровой сессии: {storedSession.Id} - {storedSession.Name}");
            }

            var response = _responseFactory.Create(storedSession, storedSessionGame);

            return response;
        }

        public async Task<GameSessionResponse> GetAsync(int id)
        {
            var session = await _sessionRepository.GetAsync(id);

            if (session == null)
                throw new GameSessionNotFoundException($"Не удалось найти игровую сессию по идентификатору: {id}");

            var boardGame = await _boardGameRepository.GetAsync(session.BoardGameId);
            if(boardGame == null)
            {
                throw new GameNotFoundException($"Не удалось найти настольную игру (id: {session.BoardGameId}) " +
                    $"для игровой сессии: {session.Id} - {session.Name}");
            }

            var response = _responseFactory.Create(session, boardGame);

            return response;
        }

        //TODO: получать только будущие игровые сессии
        //TODO: либо отдельным сценарием, либо фильтром: искать сценарии в истории
        //TODO: получать только те игры, которые есть в сессиях
        public async Task<GameSessionListResponse> ListAsync()
        {
            var sessions = await _sessionRepository.ListAsync();
            var games = await _boardGameRepository.ListAsync();

            var sessionResponses = new List<GameSessionResponse>();
            foreach (var session in sessions) 
            {
                var boardGame = games.FirstOrDefault(x => x.Id == session.BoardGameId);

                if(boardGame == null)
                {
                    throw new GameNotFoundException($"Не удалось найти настольную игру (id: {session.BoardGameId}) " +
                        $"для игровой сессии: {session.Id} - {session.Name}");
                }

                var sessionResponse = _responseFactory.Create(session, boardGame);
                sessionResponses.Add(sessionResponse);
            }

            return new GameSessionListResponse() { Sessions = sessionResponses };

        }
    }
}
