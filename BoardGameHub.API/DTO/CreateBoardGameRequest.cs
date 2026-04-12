using System.ComponentModel.DataAnnotations;

namespace BoardGameHub.API.DTO
{
    public class CreateBoardGameRequest
    {
        [Required]
        public string Title { get; init; }

        [Range(1, 5000)]
        public int DurationMinutes { get; init; }
        [Range(1, 100)]
        public int? MinPlayersCount { get; init; }
        [Range(1, 100)]
        public int? MaxPlayersCount { get; init; }
    }
}
