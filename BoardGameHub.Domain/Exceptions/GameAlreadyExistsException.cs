namespace BoardGameHub.Domain.Exceptions
{
    public class GameAlreadyExistsException : DomainException
    {
        public GameAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
