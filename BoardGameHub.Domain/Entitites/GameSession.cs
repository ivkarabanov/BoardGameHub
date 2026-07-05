using BoardGameHub.Domain.Enums;
using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Entitites
{
    public class GameSession
    {
        public GameSession(int id, BoardGameId boardGameId, GameSessionName name, GameSessionSceduledAt scheduledAt, GameSessionStatus status)
            :this(boardGameId, name, scheduledAt, status)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Идентификатор сессии должен быть больше 0");
            }

            Id = id;
        }

        private GameSession(BoardGameId boardGameId, GameSessionName name, GameSessionSceduledAt scheduledAt, GameSessionStatus status)
        {
            BoardGameId = boardGameId;
            Name = name;
            ScheduledAt = scheduledAt;
            Status = status;

            if (Id == 0 && Status != GameSessionStatus.Planed)
            {
                throw new ArgumentOutOfRangeException(nameof(status), "Неверный статус для новой игровой сессии");
            }
        }

        public int Id { get; private set; }
        
        public BoardGameId BoardGameId { get; private set; }

        public GameSessionName Name {  get; private set; }

        public GameSessionSceduledAt ScheduledAt { get; private set; }

        public GameSessionStatus Status { get; private set; } = GameSessionStatus.Planed;


        public void Start()
        {
            if (Status != GameSessionStatus.Opened)
            {
                throw new IncorrectGameSessionOperationException("Игровая сессия долджна быть открыта перед запуском. Нелья выполнить операцию.");
            }

            Status = GameSessionStatus.InProgress;
        }

        public void Open()
        {
            if (Status != GameSessionStatus.Planed)
            {
                throw new IncorrectGameSessionOperationException("Игровая сессия должна быть запланирована. Нелья выполнить операцию.");
            }

            Status = GameSessionStatus.Opened;
        }

        public  void Complete()
        {
            if (Status != GameSessionStatus.InProgress)
            {
                throw new IncorrectGameSessionOperationException("Нельзя завершить сессию, если она не начата. Нелья выполнить операцию.");
            }

            Status = GameSessionStatus.Finished;
        }

        public void Cancel()
        {
            if (Status == GameSessionStatus.Cancelled)
            {
                throw new IncorrectGameSessionOperationException("Игровая сессия уже отменена. Нелья выполнить операцию.");
            }

            Status = GameSessionStatus.Cancelled;
        }

        public static GameSession CreateNew(BoardGameId boardGameId, GameSessionName name, GameSessionSceduledAt scheduledAt)
        {
            return new GameSession(boardGameId, name, scheduledAt, GameSessionStatus.Planed);
        }

        public static GameSession CreateWithId(int id, GameSession gameSession)
        {
            return new GameSession(id, gameSession.BoardGameId, gameSession.Name, gameSession.ScheduledAt, gameSession.Status);
        }
    }
}
