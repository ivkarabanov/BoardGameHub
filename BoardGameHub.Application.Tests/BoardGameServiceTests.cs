using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Models;
using BoardGameHub.Domain;
using Moq;

namespace BoardGameHub.Application.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateAsync_PassModel_CreateDomainBoardGame()
        {
            var mockRepositry = new Mock<IBoardGameRepository>();
            mockRepositry.Setup(x => x.AddAsync(It.IsAny<BoardGame>()))
                .Returns((BoardGame x) => Task.FromResult(x));

            var boardGameService = new BoardGameService(mockRepositry.Object);
            string boardGameTitle = "Новая игра";
            var gameModel = new CreateBoardGameModel() { Title = boardGameTitle, DurationMinutes=100, MinPlayersCount=1 };

            var createdBoardGame = await boardGameService.CreateAsync(gameModel);

            Assert.That(createdBoardGame, Is.Not.Null);
            Assert.That(createdBoardGame.Title.Value, Is.EqualTo(boardGameTitle));
            mockRepositry.Verify((x)=>x.AddAsync(It.IsAny<BoardGame>()),Times.Once);
            mockRepositry.VerifyNoOtherCalls();
        }
    }
}
