using BoardGameHub.Domain.Exceptions;

namespace BoardGameHub.Domain.ValueObjects
{
    public record PlayerCountRange
    {
        public int? Min { get; }
        public int? Max { get; }

        public PlayerCountRange(int? min, int? max)
        {
            if (min is <= 0)
                throw new IncorrectPlayersCountException("Минимальное число игроков должно быть больше 0");

            if (max is <= 0)
                throw new IncorrectPlayersCountException("Максимальное число игроков должно быть больше 0");

            if (min.HasValue && max.HasValue && min > max)
                throw new IncorrectPlayersCountException("Минимальное число игроков не может быть больше максимального числа игроков");

            Min = min;
            Max = max;
        }

        public override string ToString() =>
            Min.HasValue && Max.HasValue
                ? $"Число игроков: {Min}-{Max}"
                : Min.HasValue
                    ? $"Число игроков: от {Min}"
                    : Max.HasValue
                        ? $"Число игроков: до {Max}"
                        : "Число игроков: неизвестно";
    }
}
