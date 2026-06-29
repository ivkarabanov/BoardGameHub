using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class PlayerCountRangeTests
    {
        [Test]
        [TestCase(10, 5)]
        [TestCase(-2, 5)]
        [TestCase(5, 0)]
        public void Ctor_IncorrectNumbers_ShouldThowsDomainException(int? minValue, int? maxValue)
        {
            Assert.Throws(typeof(IncorrectPlayersCountException), () => new PlayerCountRange(minValue, maxValue));
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(null, null)]
        public void Ctor_СorrectNumbers_ShouldCreateObject(int? minValue, int? maxValue)
        {
            var playerCountRange = new PlayerCountRange(minValue, maxValue);

            Assert.That(playerCountRange.Min, Is.EqualTo(minValue));
            Assert.That(playerCountRange.Max, Is.EqualTo(maxValue));
        }


        [Test]
        public void Equals_DifferentRanges_ShouldReturnFalse()
        {
            var range1 = new PlayerCountRange(10, 15);
            var range2 = new PlayerCountRange(10, 14);

            var result = range1.Equals(range2);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_SameRanges_ShouldReturnTrue()
        {
            var range1 = new PlayerCountRange(10, 15);
            var range2 = new PlayerCountRange(10, 15);

            var result = range1.Equals(range2);

            Assert.That(result, Is.True);
        }
    }
}
