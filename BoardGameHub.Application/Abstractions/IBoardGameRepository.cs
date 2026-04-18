using BoardGameHub.Domain;

namespace BoardGameHub.Application.Abstractions
{
    public interface IBoardGameRepository
    {
        Task<BoardGame> AddAsync(BoardGame game);
        Task<BoardGame> GetAsync(int id);
        Task<List<BoardGame>> ListAsync();
    }
}
