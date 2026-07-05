using BoardGameHub.API.DTO;
using BoardGameHub.Application.Models;

namespace BoardGameHub.Application.Abstractions
{
    public interface IBoardGameService
    {
        Task<BoardGameListResponse> ListAsync();

        Task<BoardGameResponse> CreateAsync(CreateBoardGameRequest boardGameModel);

        Task<BoardGameResponse> GetAsync(int id);
    }
}
