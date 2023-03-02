using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class EventEntityRepository : IEventEntityRepository
    {
        public Task AddGameToEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameFromEventByIdAsync(int id, int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<EventEntity> GetEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<EventEntity>> GetEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<EventEntity>> GetGamesFromEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EventEntity> UpdateEventAsync(EventEntity eventEntity)
        {
            throw new NotImplementedException();
        }
    }
}