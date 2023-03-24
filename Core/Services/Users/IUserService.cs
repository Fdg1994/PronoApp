using Core.Models;

namespace Core.Services.Users
{
    public interface IUserService
    {
        Task<User> PlaceBet(int userId, Game game, int betOutcome, int betAmount);
    }
}