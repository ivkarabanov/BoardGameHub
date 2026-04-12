using AutoMapper;
using BoardGameHub.API.DTO;
using BoardGameHub.Domain;

namespace BoardGameHub.API.Mappers
{
    public class BoardGameProfile:Profile
    {
        public BoardGameProfile()
        {
            CreateMap<CreateBoardGameRequest, BoardGame>()
               .ConstructUsing(x => new BoardGame(0, x.Title, x.DurationMinutes, x.MinPlayersCount, x.MaxPlayersCount));
            CreateMap<BoardGame, BoardGameResponse>();
        }
    }
}
