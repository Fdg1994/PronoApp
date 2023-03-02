using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface IEventEntityRepository
    {
        Task<EventEntity> UpdateEventAsync(EventEntity eventEntity);
        Task DeleteEventByIdAsync(int id);
        Task<EventEntity> GetEventByIdAsync(int id);
        Task<IReadOnlyList<EventEntity>> GetEventsAsync();
        Task<IList<EventEntity>> GetGamesFromEventByIdAsync(int id);
        Task AddGameToEvent(int id);
        Task DeleteGameFromEventByIdAsync(int id, int gameId);
    }
}