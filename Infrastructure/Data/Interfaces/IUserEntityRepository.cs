using Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserEntityRepository
    {
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<IReadOnlyList<UserEntity>> GetUsersAsync();
    }
}
