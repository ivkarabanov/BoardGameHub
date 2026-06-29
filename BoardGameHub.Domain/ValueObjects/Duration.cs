using System.Diagnostics.CodeAnalysis;

namespace BoardGameHub.Domain.ValueObjects
{
    public struct Duration : IEquatable<Duration>
    {
        public Duration(int minutes)
        {
            if(minutes <= 0)
                throw new ArgumentOutOfRangeException(nameof(minutes));

            Minutes = minutes;
        }

        public int Minutes { get; }

        public bool Equals(Duration other)
        {
            return Minutes == other.Minutes;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if(obj == null || obj is not Duration duration)
            {
                return false;
            }

            return Equals(duration);
        }

        public static bool operator ==(Duration left, Duration right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Duration left, Duration right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Minutes.GetHashCode();
        }
    }
}
