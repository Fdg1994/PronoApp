using AutoMapper;
using Core.Interfaces;
using Core.Models;

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

            if(game.StartTimeGame > DateTime.Now)
            {
                throw new Exception("Game has already started");
            }

            if (betAmount > user.Points)
            {
                throw new Exception("Bet amount exceeds available points");
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
            User entity = await _userRepository.GetUserByIdAsync(userId);
            User model = _mapper.Map<User>(entity);

            return model;
        }
    }
}