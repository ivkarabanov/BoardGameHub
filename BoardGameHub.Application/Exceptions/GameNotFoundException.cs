using BoardGameHub.Application.Exceptions;

namespace BoardGameHub.Domain.Exceptions
{
    public class GameNotFoundException : UseCaseException
    {
        public GameNotFoundException(string? message) : base(message)
        {
        }
    }
}
