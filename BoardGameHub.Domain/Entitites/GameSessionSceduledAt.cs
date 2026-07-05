namespace BoardGameHub.Domain.Entitites
{
    public record GameSessionSceduledAt
    {
        public GameSessionSceduledAt(DateTime sceduledAt) 
        {
            if (sceduledAt == default)
            {
                throw new ArgumentOutOfRangeException(nameof(sceduledAt), "Неверные дата/время игровой сессии");
            }
            Value = sceduledAt;
        }

        public DateTime Value { get;  }
    }
}
