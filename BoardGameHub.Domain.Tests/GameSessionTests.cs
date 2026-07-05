using BoardGameHub.Domain.Entitites;
using BoardGameHub.Domain.Enums;
using BoardGameHub.Domain.Exceptions;
using BoardGameHub.Domain.ValueObjects;

namespace BoardGameHub.Domain.Tests
{
    public class GameSessionTests
    {
        [Test]
        public void CreateNew_WithValidValues_ShouldCreateObject()
        {
            var gameId = new BoardGameId(1);
            var name = new GameSessionName("моя сессия");
            var scheduledAt = new GameSessionSceduledAt(DateTime.Now.AddDays(1));

            var session = GameSession.CreateNew(gameId, name, scheduledAt);

            Assert.That(session, Is.Not.Null);
            Assert.That(session.Status, Is.EqualTo(GameSessionStatus.Planed));
            Assert.That(session.Id, Is.EqualTo(0));
            Assert.That(session.BoardGameId, Is.EqualTo(gameId));
            Assert.That(session.Name, Is.EqualTo(name));
            Assert.That(session.ScheduledAt, Is.EqualTo(scheduledAt));
        }

        [Test]
        public void Cancel_CallOnce_ShouldChangeStatus()
        {
            var gameId = new BoardGameId(1);
            var name = new GameSessionName("моя сессия");
            var scheduledAt = new GameSessionSceduledAt(DateTime.Now.AddDays(1));
            var session = GameSession.CreateNew(gameId, name, scheduledAt);
            var stateBefore = session.Status;

            session.Cancel();
            var stateAfer = session.Status;

            Assert.That(stateAfer, Is.Not.EqualTo(stateBefore));
            Assert.That(stateAfer, Is.EqualTo(GameSessionStatus.Cancelled));
        }

        [Test]
        public void Cancel_CallTwice_ShouldThowsDomainException()
        {
            var gameId = new BoardGameId(1);
            var name = new GameSessionName("моя сессия");
            var scheduledAt = new GameSessionSceduledAt(DateTime.Now.AddDays(1));
            var session = GameSession.CreateNew(gameId, name, scheduledAt);
            var stateBefore = session.Status;

            session.Cancel();
            Assert.Throws(typeof(IncorrectGameSessionOperationException), ()  => session.Cancel());
        }

    }
}
