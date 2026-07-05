using BoardGameHub.API.DTO;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Services;
using BoardGameHub.Domain.Entitites;
using BoardGameHub.Domain.Tests.TestTools;
using Moq;

namespace BoardGameHub.Application.Tests
{
    public class BoardGameServiceTests
    {
        [Test]
        public async Task CreateAsync_PassModel_CreateDomainBoardGame()
        {
            var mockRepositry = new Mock<IBoardGameRepository>();
            mockRepositry.Setup(x => x.AddAsync(It.IsAny<BoardGame>()))
                .Returns((BoardGame x) => Task.FromResult(x));
            var mappper = MapperFactory.Create();

            var boardGameService = new BoardGameService(mockRepositry.Object, mappper);
            string boardGameTitle = "Новая игра";
            var gameModel = new CreateBoardGameRequest() { Title = boardGameTitle, DurationMinutes=100, MinPlayersCount=1 };

            var createdBoardGame = await boardGameService.CreateAsync(gameModel);

            Assert.That(createdBoardGame, Is.Not.Null);
            Assert.That(createdBoardGame.Title, Is.EqualTo(boardGameTitle));
            mockRepositry.Verify((x)=>x.AddAsync(It.IsAny<BoardGame>()),Times.Once);
            mockRepositry.VerifyNoOtherCalls();
        }
    }
}
