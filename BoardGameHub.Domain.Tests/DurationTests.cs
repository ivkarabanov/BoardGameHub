using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    internal class DurationTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_NotPositiveValue_ThrowException(int duration)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException),() => new Duration(duration));
        }

        [Test]
        public void Ctor_Positivealue_ShouldCreateCorrectObject()
        {
            int minutes = 2;
            var duration = new Duration(minutes);

            Assert.That(duration.Minutes, Is.EqualTo(minutes));
        }
    }
}
