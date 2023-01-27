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
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<UserEntity>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
