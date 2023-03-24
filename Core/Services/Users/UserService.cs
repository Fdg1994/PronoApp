using AutoMapper;
using Core.Application.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Models;
using Core.Services.Users;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> PlaceBet(int userId, Game game, int betOutcome, int betAmount)
        {
            User user = await GetUser(userId);

            if (game.StartTimeGame > DateTime.Now)
            {
                throw new Exception("Game has already started");
            }

            if (betAmount > user.Points)
            {
                throw new Exception("Bet amount exceeds available points");
            }

            if (user.Bets.Any(b => b.User.Id == user.Id && b.Game.Id == game.Id))
            {
                throw new Exception("Bet already placed");
            }

            user.Points -= betAmount;
            var bet = new Bet
            {
                User = user,
                PredictedOutcome = (Enums.PredictedOutcome)betOutcome,
                Game = game,
                BetAmount = betAmount
            };

            user.Bets.Add(bet);

            await _userRepository.AddBetToUserAsync(user.Id, game.Id, bet.BetAmount, (int)bet.PredictedOutcome);
            return user;
        }

        private async Task<User> GetUser(int userId)
        {
            UserEntity entity = await _userRepository.GetByIdAsync(userId);
            User model = _mapper.Map<User>(entity);

            return model;
        }
    }
}