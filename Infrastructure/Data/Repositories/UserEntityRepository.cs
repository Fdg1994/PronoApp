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

        public async Task AddBetToUserAsync(int userId, int betId)
        {
            var bet = await _context.Bets.SingleOrDefaultAsync(u => u.Id == userId);
            var user = await GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            if (user.Bets.Any(user => bet.Id == bet.Id))
            {
                return;
            }

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
