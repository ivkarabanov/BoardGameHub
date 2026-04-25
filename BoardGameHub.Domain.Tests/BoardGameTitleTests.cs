using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{

    public class Tests
    {
        [Test]
        [TestCase(null,typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException)),]
        [TestCase(" ", typeof(ArgumentException))]
        public void Ctor_EmptyTitle_ShouldThrowExceltion(string? emptyTitle, Type expectedExceptionType)
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
    }
}
