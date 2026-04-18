namespace BoardGameHub.Domain.Exceptions
{
    public class IncorrectPlayersCountException : DomainException
    {
        public IncorrectPlayersCountException(string? message) : base(message)
        {
        }
    }
}
