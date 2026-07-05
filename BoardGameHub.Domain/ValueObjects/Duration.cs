namespace BoardGameHub.Domain.ValueObjects
{
    public record Duration
    {
        public Duration(int minutes)
        {
            if(minutes <= 0)
                throw new ArgumentOutOfRangeException(nameof(minutes));

            Minutes = minutes;
        }

        public int Minutes { get; }
    }
}
