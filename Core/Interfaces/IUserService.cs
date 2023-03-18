using Core.Models;


namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> PlaceBet(int userId, Game game, int betOutcome, int betAmount);
    }
}