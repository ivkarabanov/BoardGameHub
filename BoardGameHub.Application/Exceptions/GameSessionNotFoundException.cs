namespace BoardGameHub.Application.Exceptions
{
    public class GameSessionNotFoundException : UseCaseException
    {
        public GameSessionNotFoundException(string? message) : base(message)
        {
        }
    }
}
