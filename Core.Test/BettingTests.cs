using AutoMapper;
using Core.Configuration;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Moq;

namespace Core.Test
{
    public class BettingTests
    {
        private IUserService _userService;
        private Game game;

        [SetUp]
        public void Setup()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(GetDummyUser());

            var config = new MapperConfiguration(m => m.AddProfile<CoreProfile>());
            var mapper = config.CreateMapper();

            game = new Game();

            _userService = new UserService(userRepository.Object, mapper);
        }

        private User GetDummyUser()
        {
            return new User
            {
                Id = 1,
                Points = 10,
            };
        }

        [Test]
        public async Task WhenUserPlacesBet_ThenSubstractPointsFromUserPointsAsync()
        {
            //Arrange
            int teamId = 2;

            //Act
            User user = await _userService.PlaceBet(1, game, teamId);

            //Assert
            Assert.That(user.Points, Is.EqualTo(9));
        }

        [Test]
        public async Task WhenUserPlacesBet_ThenAddPointToBetAsync()
        {
            //Arrange
            var teamId = 2;
            int betAmount = 5;

            //Act
            User user  = await _userService.PlaceBet(1, game, teamId, betAmount);

            //Assert
            Assert.That(user.Bets.Count, Is.EqualTo(1));
            Assert.That(user.Bets[0].BetAmount, Is.EqualTo(5));
        }
    }
}