using BoardGameHub.Application.Models;
using BoardGameHub.Domain;

namespace BoardGameHub.Application.Abstractions
{
    public interface IBoardGameService
    {
        Task<List<BoardGame>> ListAsync();

        Task<BoardGame> CreateAsync(CreateBoardGameModel boardGameModel);

        Task<BoardGame> GetAsync(int id);
    }
}
