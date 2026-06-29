namespace BoardGameHub.Application.Abstractions
{
    public interface IDateTimeProvider
    {
        public DateTime GetNow();

        public DateOnly GetToday();
    }
}
