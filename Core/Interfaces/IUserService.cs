using Core.Models;
using Infrastructure.Data.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> PlaceBet(int userId, Game game, PredictedOutcome betOutcome, int betAmount = 1);
    }
}