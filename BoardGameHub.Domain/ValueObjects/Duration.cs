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
            return base.Equals(obj);
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
