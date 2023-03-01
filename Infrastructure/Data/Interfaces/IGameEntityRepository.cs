using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface IGameEntityRepository
    {
        Task<GameEntity> GetGameByIdAsync(int id);
        Task<IReadOnlyList<GameEntity>> GetGamesAsync();
        Task<GameEntity> UpdateEventAsync(GameEntity game);
    }
}