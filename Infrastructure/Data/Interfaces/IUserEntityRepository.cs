using Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserEntityRepository
    {
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<IReadOnlyList<UserEntity>> GetUsersAsync();
        Task AddBetToUserAsync(int id, int gameId, int amount,PredictedOutcome predictedOutcome);
        Task<IList<UserEntity>> GetBetsFromUserByIdAsync(int id);
    }
}
