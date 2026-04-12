using BoardGameHub.Domain;

namespace BoardGameHub.Infrastructure.Abstractions
{
    public interface IBoardGameRepository
    {
        Task<BoardGame> AddAsync(BoardGame game);

        Task<List<BoardGame>> ListAsync();
    }
}
