namespace BoardGameHub.Domain
{
    public class BoardGame
    {
        public BoardGame(int id, string title, int durationMinutes,
            int? minPlayersCount = null, int? maxPlayersCount = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(durationMinutes, 0, nameof(durationMinutes));

            Id = id;
            Title = title;
            DurationMinutes = durationMinutes;
            MinPlayersCount = minPlayersCount;
            MaxPlayersCount = maxPlayersCount; 
        }

        public int Id { get; set; }

        public string Title { get;  }

        public int DurationMinutes { get; }

        public int? MinPlayersCount { get; }

        public int? MaxPlayersCount { get;  }
    }
}
