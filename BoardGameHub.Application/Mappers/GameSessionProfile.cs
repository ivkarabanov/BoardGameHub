using AutoMapper;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Application.Mappers
{
    public class GameSessionProfile:Profile
    {
        public GameSessionProfile()
        {
            CreateMap<GameSession, GameSessionResponse>();
        }
    }
}
