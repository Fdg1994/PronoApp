using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface ICompanyEntityRepository
    {
        Task<CompanyEntity> GetCompanyByIdAsync(int id);
        Task<IReadOnlyList<CompanyEntity>> GetCompaniesAsync();
        Task AddUserToCompanyAsync(int id,string name,string password);
    }
}