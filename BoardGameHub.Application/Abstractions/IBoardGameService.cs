using BoardGameHub.Domain;
using BoardGameHub.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameHub.Application.Abstractions
{
    public interface IBoardGameService
    {
        Task<List<BoardGame>> ListAsync();

        Task<BoardGame> AddAsync(BoardGame boardGame);
    }
}
