using BoardGameHub.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace BoardGameHub.Domain.ValueObjects
{
    public struct PlayerCountRange : IEquatable<PlayerCountRange>
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

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is not PlayerCountRange playerCountRange)
                return false;

            return Equals(playerCountRange);
        }
            

        public bool Equals(PlayerCountRange other)
        {
            return Min == other.Min && Max == other.Max;
        }

        public override int GetHashCode() =>
            HashCode.Combine(Min, Max);

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
