using BoardGameHub.Application.Abstractions;

namespace BoardGameHub.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }

        public DateOnly GetToday()
        {
            return DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
