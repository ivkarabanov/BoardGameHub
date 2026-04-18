using BoardGameHub.API.Mappers;
using BoardGameHub.Application;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Mappers;
using BoardGameHub.Infrastructure;

namespace BoardGameHub.API.Services
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(BoardGameProfile));
            });
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBoardGameRepository, InMemoryBoardGameRepository>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBoardGameService, BoardGameService>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(ApplicationModelsProfile));
            });
            return services;
        }
    }
}
