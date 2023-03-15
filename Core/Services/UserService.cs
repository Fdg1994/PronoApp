using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Data.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private IUserEntityRepository _userEntityRepository;
        private IMapper _mapper;

        public UserService(IUserEntityRepository userEntityRepository, IMapper mapper)
        {
            _userEntityRepository = userEntityRepository;
            _mapper = mapper;
        }

        public async Task<User> PlaceBet(int userId, Game game, PredictedOutcome betOutcome, int betAmount = 1)
        {
            User user = await GetUser(userId);

            user.Points--;
            var bet = new Bet
            {
                User = user,
                PredictedOutcome = betOutcome,
                Game = game,
                BetAmount = betAmount
            };
            user.Bets.Add(bet);

            await _userEntityRepository.AddBetToUserAsync(user.Id, game.Id, bet.BetAmount, (int)bet.PredictedOutcome);
            return user;
        }

        private async Task<User> GetUser(int userId)
        {
            UserEntity entity = await _userEntityRepository.GetUserByIdAsync(userId);
            User model = _mapper.Map<User>(entity);

            return model;
        }
    }
}