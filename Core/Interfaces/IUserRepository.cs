using Core.Models;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);

        Task<IReadOnlyList<User>> GetUsersAsync();

        Task AddBetToUserAsync(int userId, int gameId, int amount, int predictedOutcome);

        Task<IList<Bet>> GetBetsFromUserByIdAsync(int id);

        Task<Bet> GetBetFromUserByIdAsync(int id, int betId);

        Task DeleteBetFromUserByIdAsync(int id, int betId);
    }
}
