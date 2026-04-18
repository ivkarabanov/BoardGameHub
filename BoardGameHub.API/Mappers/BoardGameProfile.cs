using AutoMapper;
using BoardGameHub.API.DTO;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain;

namespace BoardGameHub.API.Mappers
{
    public class BoardGameProfile:Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGame, BoardGameResponse>();
            CreateMap<CreateBoardGameRequest, CreateBoardGameModel>();
        }
    }
}
