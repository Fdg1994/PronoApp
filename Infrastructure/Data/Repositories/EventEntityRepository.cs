using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EventEntityRepository : IEventEntityRepository
    {
        private readonly DataContext _context;
        public EventEntityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(string name, string logo)
        {
            var eventEntity = new EventEntity
            {
                Name = name,
                logoUrl = logo,
                Games = new List<GameEntity>()
            };
            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task AddGameToEventAsync(int id, string team1, string team2)
        {
            var eventEntity = await GetEventByIdAsync(id);
            if (eventEntity == null)
            {
                throw new ArgumentException("Event not found.");
            }

            var game = new GameEntity
            {
                EventEntityId = id,
                Team1 = team1,
                Team2 = team2
            };

            eventEntity.Games.Add(game);

            await _context.SaveChangesAsync();
        }


        public Task DeleteEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameFromEventByIdAsync(int id, int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<EventEntity> GetEventByIdAsync(int id)
        {
            return await _context.Events
            .Include(e => e.Games)
            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<EventEntity>> GetEventsAsync()
        {
            return await _context.Events
            .Include(e => e.Games)
            .ToListAsync();
        }

        public Task<EventEntity> UpdateEventAsync(EventEntity eventEntity)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> EventExists(string name)
        {
            return await _context.Events.AnyAsync(x => x.Name == name.ToLower());
        }
    }
}