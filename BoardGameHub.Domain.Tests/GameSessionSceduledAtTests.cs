using BoardGameHub.Domain.Entitites;

namespace BoardGameHub.Domain.Tests
{
    public class GameSessionSceduledAtTests
    {
        [Test]
        public void Ctor_IncorrectValue_ShouldThrowsArgumentException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new GameSessionSceduledAt(default));
        }
    }
}
