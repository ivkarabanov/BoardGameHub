namespace BoardGameHub.Domain.Exceptions
{
    public class GameNotFoundException : DomainException
    {
        public GameNotFoundException(string? message) : base(message)
        {
        }
    }
}
