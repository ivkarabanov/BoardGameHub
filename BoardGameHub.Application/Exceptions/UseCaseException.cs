namespace BoardGameHub.Application.Exceptions
{
    public abstract class UseCaseException:Exception
    {
        protected UseCaseException(string? message) : base(message)
        {
        }
    }
}
