using Data.Interfaces;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserEntityRepository:IUserEntityRepository
    {
        private readonly DataContext _context;
        public UserEntityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Company)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<UserEntity>> GetUsersAsync()
        {
            return await _context.Users
            .Include(u => u.Company)
            .ToListAsync();
        }

        public async Task AddBetToUserAsync(int id, int gameId, int amount,PredictedOutcome predictedOutcome)
        {
            var user = await GetUserByIdAsync(id);
            var game = await _context.Games.SingleOrDefaultAsync(g => g.Id == gameId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            if (game == null)
            {
                throw new ArgumentException("Game not found.");
            }

            if (user.Bets.Any(b => b.UserEntityId == id && b.GameEntityId == gameId))
            {
                throw new ArgumentException("Bet already placed.");
            }

            var bet = new BetEntity()
            {
                BetAmount = amount,
                PredictedOutcome = predictedOutcome,
                UserEntityId = id,
                GameEntityId = gameId
            };
        
            user.Bets.Add(bet);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<UserEntity>> GetBetsFromUserByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id)
            .Include(u => u.Bets)
            .ToListAsync();
        }
    }
}
