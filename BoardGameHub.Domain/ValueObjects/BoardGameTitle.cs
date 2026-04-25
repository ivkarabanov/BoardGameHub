using System.Diagnostics.CodeAnalysis;

namespace BoardGameHub.Domain.ValueObjects
{
    public struct BoardGameTitle : IEquatable<BoardGameTitle>
    {
        public BoardGameTitle(string title)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            Value = title;
        }

        public string Value { get; }

        public bool Equals(BoardGameTitle other)
        {
            return Value == other.Value;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(BoardGameTitle left, BoardGameTitle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BoardGameTitle left, BoardGameTitle right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
