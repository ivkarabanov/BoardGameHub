using AutoMapper;
using BoardGameHub.API.Mappers;
using Microsoft.Extensions.Logging.Abstractions;

namespace BoardGameHub.Domain.Tests.TestTools
{
    internal static class MapperFactory
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(BoardGameProfile)), new NullLoggerFactory());
            return config.CreateMapper();
        }
    }
}
