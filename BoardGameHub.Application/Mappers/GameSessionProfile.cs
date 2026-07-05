using AutoMapper;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Application.Mappers
{
    public class GameSessionProfile:Profile
    {
        public GameSessionProfile()
        {
            CreateMap<GameSession, GameSessionResponse>()
                .ForMember(x => x.ScheduledAt, opt => opt.MapFrom(d => d.ScheduledAt.Value))
                 .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name.Value));
        }
    }
}
