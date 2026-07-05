namespace BoardGameHub.Domain.ValueObjects
{
    public record BoardGameId
    {
        public BoardGameId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Идентификатор настольной игры не может быть отрицательным");
            }

            Value = id;
        }
        public int Value { get; }
    }
}
