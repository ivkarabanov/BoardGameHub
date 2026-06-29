namespace BoardGameHub.Application.Models
{
    public class GameSessionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BoardGameName { get; set; }

        public DateTime ScheduledAt { get; set; }

        public string Status { get; set; }
    }
}
