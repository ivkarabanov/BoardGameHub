using System.ComponentModel.DataAnnotations;

namespace BoardGameHub.Application.Models
{
    public class CreateGameSessionRequest
    {
        [Required]
        public int BoardGameId { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime ScheduledAt { get; set; }
    }
}
