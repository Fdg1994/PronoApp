using Infrastructure.Data.Interfaces;

namespace API.Controllers
{
    public class EventsController
    {
        private readonly IEventEntityRepository _repo;

        public EventsController(IEventEntityRepository repo)
        {
            _repo = repo;
        }

        
    }
}