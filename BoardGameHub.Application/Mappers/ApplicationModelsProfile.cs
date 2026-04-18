using AutoMapper;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain;

namespace BoardGameHub.Application.Mappers
{
    public class ApplicationModelsProfile:Profile
    {
        public ApplicationModelsProfile()
        {
            CreateMap<CreateBoardGameModel, BoardGame>()
                .ConstructUsing(x => new BoardGame(0, x.Title, x.DurationMinutes, x.MinPlayersCount, x.MaxPlayersCount));
        }
    }
}
