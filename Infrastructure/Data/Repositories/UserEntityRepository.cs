using Core.Enums;
using Data.Interfaces;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserEntityRepository : IUserEntityRepository
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
                .Include(u => u.Bets)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<UserEntity>> GetUsersAsync()
        {
            return await _context.Users
            .Include(u => u.Company)
            .Include(u => u.Bets)
            .ToListAsync();
        }

        public async Task AddBetToUserAsync(int id, int gameId, int amount, int predictedOutcome)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            var game = await _context.Games.SingleOrDefaultAsync(g => g.Id == gameId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            if (game == null)
            {
                throw new ArgumentException("Game not found.");
            }

            var bets = user.Bets ?? new List<BetEntity>();

            var bet = new BetEntity()
            {
                UserEntityId = id,
                GameEntityId = gameId,
                BetAmount = amount,
                PredictedOutcome = (PredictedOutcome)predictedOutcome
            };

            user.Bets = bets;
            user.Bets.Add(bet);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<BetEntity>> GetBetsFromUserByIdAsync(int id)
        {
            return await _context.Bets.Where(b => b.UserEntityId == id)
            .Include(b => b.Game)
            .ToListAsync();
        }

        public async Task DeleteBetFromUserByIdAsync(int id, int betId)
        {
            var user = await GetUserByIdAsync(id);
        }

        public async Task<BetEntity> GetBetFromUserByIdAsync(int id, int betId)
        {
            return await _context.Bets.Where(b => b.UserEntityId == id)
            .Include(b => b.Game)
            .FirstOrDefaultAsync();
        }
    }
}