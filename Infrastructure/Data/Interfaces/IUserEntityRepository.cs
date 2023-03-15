using Infrastructure.Data.Entities;

namespace Data.Interfaces
{
    public interface IUserEntityRepository
    {
        Task<UserEntity> GetUserByIdAsync(int id);

        Task<IReadOnlyList<UserEntity>> GetUsersAsync();

        Task AddBetToUserAsync(int id, int gameId, int amount, string predictedOutcome);

        Task<IList<BetEntity>> GetBetsFromUserByIdAsync(int id);

        Task<BetEntity> GetBetFromUserByIdAsync(int id, int betId);

        Task DeleteBetFromUserByIdAsync(int id, int betId);
    }
}