using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{

    public class BoardGameTitleTests
    {
        [Test]
        [TestCase(null,typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException)),]
        [TestCase(" ", typeof(ArgumentException))]
        public void Ctor_EmptyTitle_ShouldThrowException(string? emptyTitle, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => new BoardGameTitle(emptyTitle));
        }

        [Test]

        public void Ctor_CorrectTitle_ShouldCreateTitle()
        {
            string boardGameName = "Название";
            var title = new BoardGameTitle(boardGameName);

            Assert.That(title.Value, Is.EqualTo(boardGameName));
        }

        [Test]
        [TestCase("одно название", "другое название")]
        [TestCase("отличаются регистром", "ОТЛИЧАЮТСЯ РЕГИСТРОМ")]
        public void Equals_DifferentTitles_ShouldReturnFalse(string title1, string title2)
        {
            var gameTitle1 = new BoardGameTitle(title1);
            var gameTitle2 = new BoardGameTitle(title2);
            var result = gameTitle1 == gameTitle2;

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("одно название", "одно название")]
        [TestCase("Эволюция", "Эволюция")]
        public void Equals_SameTitles_ShouldReturnTrue(string title1, string title2)
        {
            var result = title1 == title2;

            Assert.That(result, Is.True);
        }
    }
}
