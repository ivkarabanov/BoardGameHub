using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class PlayerCountRangeTest
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
        public void Ctor_СorrectNumbers_ShouldCreateObject()
        {
            int minValue = 1;
            int maxValue = 10;
            var playerCountRange = new PlayerCountRange(minValue, maxValue);

            Assert.That(playerCountRange.Min, Is.EqualTo(minValue));
            Assert.That(playerCountRange.Max, Is.EqualTo(maxValue));
        }
    }
}
