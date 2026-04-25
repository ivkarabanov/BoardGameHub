using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain
{
    public class BoardGame
    {
        public BoardGame(BoardGameTitle title, Duration duration, PlayerCountRange playersCountRange)
        {
            Title = title;
            Duration = duration;
            PlayerCountRange = playersCountRange;
        }

        public BoardGame(int id, BoardGameTitle title, Duration duration,
            PlayerCountRange playerCountRange)
            :this(title, duration, playerCountRange) 
        {
            Id = id;
        }

        public int Id { get; private set; }

        public BoardGameTitle Title { get;  }

        public Duration Duration { get; }

        public PlayerCountRange PlayerCountRange { get; }

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
