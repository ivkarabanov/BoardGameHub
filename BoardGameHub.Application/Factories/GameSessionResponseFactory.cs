using AutoMapper;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain.Entitites;
using BoardGameHub.Domain.Enums;

namespace BoardGameHub.Application.Factories
{
    public class GameSessionResponseFactory:IGameSessionResponseFactory
    {
        private readonly IMapper _mapper;

        public GameSessionResponseFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public GameSessionResponse Create(GameSession gameSession, BoardGame boardGame)
        {
            var gameSessionResponse = _mapper.Map<GameSessionResponse>(gameSession);
            gameSessionResponse.BoardGameName = boardGame.Title.Value;

            SetSessionStatus(gameSession, gameSessionResponse);
            return gameSessionResponse;
        }
        
        private static void SetSessionStatus(GameSession gameSession, GameSessionResponse gameSessionResponse)
        {
            switch (gameSession.Status)
            {
                case GameSessionStatus.Planed:
                    gameSessionResponse.Status = "Запланирована";
                    break;
                case GameSessionStatus.Opened:
                    gameSessionResponse.Status = "Открыта";
                    break;
                case GameSessionStatus.InProgress:
                    gameSessionResponse.Status = "В процессе";
                    break;
                case GameSessionStatus.Finished:
                    gameSessionResponse.Status = "Закончена";
                    break;
                case GameSessionStatus.Cancelled:
                    gameSessionResponse.Status = "Отклонена";
                    break;
            }
        }
    }
}
