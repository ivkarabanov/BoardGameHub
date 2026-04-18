using BoardGameHub.Domain.Exceptions;

namespace BoardGameHub.Domain
{
    public class BoardGame
    {
        public BoardGame(string title, int durationMinutes,
            int? minPlayersCount = null, int? maxPlayersCount = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(durationMinutes, 0, nameof(durationMinutes));
            if (MinPlayersCount.HasValue && MaxPlayersCount.HasValue && MinPlayersCount > MaxPlayersCount)
                throw new IncorrectPlayersCountException("Минимальное число игроков больше, чем максимальное число игроков");

            Title = title;
            DurationMinutes = durationMinutes;
            MinPlayersCount = minPlayersCount;
            MaxPlayersCount = maxPlayersCount;
        }

        public BoardGame(int id, string title, int durationMinutes,
            int? minPlayersCount = null, int? maxPlayersCount = null)
            :this(title, durationMinutes, minPlayersCount, maxPlayersCount) 
        {
            Id = id;
        }

        public int Id { get; private set; }

        public string Title { get;  }

        public int DurationMinutes { get; }

        public int? MinPlayersCount { get; }

        public int? MaxPlayersCount { get;  }

        internal BoardGame AssignId(int id)
        {
            if (Id > 0)
                throw new InvalidOperationException("Id уже ассоциирован.");

            if (id <= 0) 
                throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;

            return this;
        }
    }
}
