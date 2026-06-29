using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class DurationTests
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

        [Test]
        public void Equals_DifferentDurations_ShouldReturnFalse()
        {
            var duration1 = new Duration(10);
            var duration2 = new Duration(11);

            var result = duration1 == duration2;

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_SameDurations_ShouldReturnTrue()
        {
            var duration1 = new Duration(15);
            var duration2 = new Duration(15);

            var result = duration1 == duration2;

            Assert.That(result, Is.True);
        }
    }
}
