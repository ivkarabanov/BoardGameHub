using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class BoardGameTests
    {
        [Test]
        public void Ctor_ValidValues_ShoulCreateObject()
        {
            var duration = new Duration(90);
            var boardGameTitle = new BoardGameTitle("Манчкин");
            var playerRangeCount = new PlayerCountRange(2, 10);

            var boardGame = new BoardGame(boardGameTitle, duration, playerRangeCount);

            Assert.That(boardGame, Is.Not.Null);
            Assert.That(boardGame.Id, Is.EqualTo(default(int)));
            Assert.That(boardGame.PlayerCountRange, Is.EqualTo(playerRangeCount));
            Assert.That(boardGame.Duration, Is.EqualTo(duration));
            Assert.That(boardGame.Title, Is.EqualTo(boardGameTitle));
        }

        [Test]
        public void CtorWithId_ValidValues_ShoulCreateObject()
        {
            var duration = new Duration(90);
            var boardGameTitle = new BoardGameTitle("Манчкин");
            var playerRangeCount = new PlayerCountRange(2, 10);
            int boardGameId = 11;

            var boardGame = new BoardGame(boardGameId, boardGameTitle, duration, playerRangeCount);

            Assert.That(boardGame, Is.Not.Null);
            Assert.That(boardGame.Id, Is.EqualTo(boardGameId));
            Assert.That(boardGame.PlayerCountRange, Is.EqualTo(playerRangeCount));
            Assert.That(boardGame.Duration, Is.EqualTo(duration));
            Assert.That(boardGame.Title, Is.EqualTo(boardGameTitle));
        }
    }
}
