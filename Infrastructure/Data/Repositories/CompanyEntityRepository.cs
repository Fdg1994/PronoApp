using System.Security.Cryptography;
using System.Text;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CompanyEntityRepository : ICompanyEntityRepository
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
        public async Task AddUserToCompanyAsync(int id, string name, string password)
        {
            using var hmac = new HMACSHA512();

            var company = await GetCompanyByIdAsync(id);
            if (company == null)
            {
                throw new ArgumentException("Company not found.");
            }

            var user = new UserEntity
            {
                UserName = name.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                CompanyEntityId = id,
                CompanyRole = CompanyRole.Member,
                Company = company
            };

            company.Members.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyNameAsync(int id, string name)
        {
            var company = await GetCompanyByIdAsync(id);
            if (company == null)
            {
                throw new ArgumentException("Company not found.");
            }

            company.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyByIdAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMemberFromCompanyByIdAsync(int id, int userId)
        {
            {
                var company = await GetCompanyByIdAsync(id);

                var member = company.Members.FirstOrDefault(m => m.Id == userId);
                if (member == null)
                {
                    throw new ArgumentException("Member does not exist in company");
                }

                company.Members.Remove(member);

                _context.SaveChanges();
            }
        }
    }
}