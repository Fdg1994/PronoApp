using Infrastructure.Data.Entities;

namespace Data.Interfaces
{
    public interface IUserEntityRepository
    {
        Task<UserEntity> GetUserByIdAsync(int id);

        Task<IReadOnlyList<UserEntity>> GetUsersAsync();

        Task AddBetToUserAsync(int userId, int gameId, int amount, int predictedOutcome);

        Task<IList<BetEntity>> GetBetsFromUserByIdAsync(int id);

        Task<BetEntity> GetBetFromUserByIdAsync(int id, int betId);

        Task DeleteBetFromUserByIdAsync(int id, int betId);
    }
}