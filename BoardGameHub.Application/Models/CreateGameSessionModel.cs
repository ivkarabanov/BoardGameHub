namespace BoardGameHub.Application.Models
{
    public class CreateGameSessionModel
    {
        public int BoardGameId { get; set; }

        public string Name { get; set; }

        public DateTime ScheduledAt { get; set; }
    }
}
