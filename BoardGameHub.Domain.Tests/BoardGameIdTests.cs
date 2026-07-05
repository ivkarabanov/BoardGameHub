using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class BoardGameIdTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Ctor_NotPossiveIdValue_ShouldThrowsArgumentException(int value)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new BoardGameId(value));            
        }
    }
}
