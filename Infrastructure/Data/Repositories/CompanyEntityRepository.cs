using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Repositories
{
    public class CompanyEntityRepository:ICompanyEntityRepository
    {
        private readonly DataContext _context;
        public CompanyEntityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<CompanyEntity> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies
            .Include(c => c.Members)
            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<CompanyEntity>> GetCompaniesAsync()
        {
            return await _context.Companies
            .Include(c => c.Members)
            .ToListAsync();
        }
        public async Task AddUserToCompanyAsync(int companyId, int userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var company = await GetCompanyByIdAsync(companyId);
            if (company == null)
            {
                throw new ArgumentException("Company not found.");
            }

            if (company.Members.Any(u => u.Id == user.Id))
            {
                return;
            }

            company.Members.Add(user);

            await _context.SaveChangesAsync();
        }
    }
}