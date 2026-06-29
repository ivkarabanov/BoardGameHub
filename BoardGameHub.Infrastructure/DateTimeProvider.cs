using BoardGameHub.Application.Abstractions;

namespace BoardGameHub.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow()
        {
            throw new NotImplementedException();
        }

        public DateOnly GetToday()
        {
            throw new NotImplementedException();
        }
    }
}
