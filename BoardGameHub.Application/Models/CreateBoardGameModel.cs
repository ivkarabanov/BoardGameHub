namespace BoardGameHub.Application.Models
{
    public class CreateBoardGameModel
    {
        public required string Title { get; init; }
        public int DurationMinutes { get; init; }
        public int? MinPlayersCount { get; init; }
        public int? MaxPlayersCount { get; init; }
    }
}
