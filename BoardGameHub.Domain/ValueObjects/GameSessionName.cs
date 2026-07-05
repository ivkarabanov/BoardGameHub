namespace BoardGameHub.Domain.ValueObjects
{
    public record GameSessionName
    {
        public GameSessionName(string title)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            Value = title;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
