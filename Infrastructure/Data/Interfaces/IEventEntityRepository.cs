using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface IEventEntityRepository
    {
        public Task AddEventAsync(string name, string logo);
        Task<EventEntity> UpdateEventAsync(EventEntity eventEntity);
        Task DeleteEventByIdAsync(int id);
        Task<EventEntity> GetEventByIdAsync(int id);
        Task<IReadOnlyList<EventEntity>> GetEventsAsync();
        Task AddGameToEventAsync(int id,string team1,string team2);
        Task DeleteGameFromEventByIdAsync(int id, int gameId);
    }
}