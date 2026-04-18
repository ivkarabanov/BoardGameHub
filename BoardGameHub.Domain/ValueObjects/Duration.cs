namespace BoardGameHub.Domain.ValueObjects
{
    public struct Duration
    {
        public Duration(int minutes)
        {
            Minutes = minutes;
        }

        public int Minutes { get; }
    }
}
