using AutoMapper;
using Core.Application.Contracts.Persistence;
using Core.Configuration;
using Core.Domain.Entities;
using Core.Models;
using Core.Services;
using Core.Services.Users;
using Moq;

namespace Core.Test
{
    public class BettingTests
    {
        private IUserService _userService;
        private Game game;
        private User user;
        private Bet bet;

        [SetUp]
        public void Setup()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(GetDummyUser());

            var config = new MapperConfiguration(m => m.AddProfile<CoreProfile>());
            var mapper = config.CreateMapper();

            game = new Game();
            user = GetDummyUser();

            _userService = new UserService(userRepository.Object, mapper);
        }

        private UserEntity GetDummyUser()
        {
            var user = new UserEntity
            {
                Id = 1,
                Points = 10,
            };

            var game = new GameEntity
            {
                Id = 1,
                Team1 = new TeamEntity(),
                Team2 = new TeamEntity(),
            };

            var newBet = new BetEntity
            {
                Id = 1,
                Game = game,
                User = user
            };

            user.Bets.Add(newBet);

            return user;
        }

        [Test]
        public async Task WhenUserPlacesBet_ThenSubstractPointsFromUserPointsAsync()
        {
            //Arrange
            int teamId = 2;
            int betAmount = 5;
            //Act
            User user = await _userService.PlaceBet(1, game, teamId, betAmount);

            //Assert
            Assert.That(user.Points, Is.EqualTo(5));
        }

        [Test]
        public async Task WhenUserPlacesBet_ThenAddPointToBetAsync()
        {
            //Arrange
            var teamId = 2;
            int betAmount = 5;

            //Act
            User user = await _userService.PlaceBet(1, game, teamId, betAmount);

            //Assert
            Assert.That(user.Bets.Count, Is.EqualTo(2));
            Assert.That(user.Bets[1].BetAmount, Is.EqualTo(5));
        }

        [Test]
        public async Task HasGameStarted_ThenDontPlaceBetAndThrowException()
        {
            //Arrange
            game.StartTimeGame = DateTime.Now.Add(TimeSpan.FromHours(1));
            var teamId = 2;
            int betAmount = 5;

            //Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await _userService.PlaceBet(1, game, teamId, betAmount));
            Assert.AreEqual("Game has already started", ex.Message);
        }

        [Test]
        public async Task IfBetAmountIsMoreThanUserPoints_ThenDontPlaceBetAndThrowException()
        {
            //Arrange
            var teamId = 2;
            int betAmount = 15;

            //Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await _userService.PlaceBet(1, game, teamId, betAmount));
            Assert.AreEqual("Bet amount exceeds available points", ex.Message);
        }

        [Test]
        public async Task IfBetAlreadyExists_ThenDontPlaceBetAndThrowException()
        {
            //Arrange
            var teamId = 2;
            int betAmount = 5;
            game.Id = 1;

            //Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await _userService.PlaceBet(1, game, teamId, betAmount));
            Assert.AreEqual("Bet already placed", ex.Message);
        }

        [Test]
        public async Task IfUserIsAdmin_ThenDontPlaceBetAndThrowException()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}