using API.DTOs;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class EventsController : BaseApiController
    {
        private readonly IEventEntityRepository _repo;

        public EventsController(IEventEntityRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous] //TO DO: Authorization
        public async Task<ActionResult<IReadOnlyList<EventDTO>>> GetEventsAsync()
        {
            var events = await _repo.GetEventsAsync();
            var eventDtos = events.Select(e => new EventDTO
            {
                Name = e.Name,
                Games = e.Games.Select(m => m.Name).ToList()
            }).ToList();

            return Ok(eventDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> GetEventByIdAsync(int id)
        {
            var eventEntity = await _repo.GetEventByIdAsync(id);

            return new EventDTO
            {
                Name = eventEntity.Name,
                Games = eventEntity.Games.Select(m => m.Name).ToList()
            };
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> AddEventAsync(EventDTO eventDto)
        {
            try
            {
                await _repo.AddEventAsync(eventDto.Name,eventDto.LogoUrl);
                return eventDto;
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("{id}/addgame")]
        [AllowAnonymous] // TO DO: authorization for manager of specific company
        public async Task<ActionResult<GameDTO>> AddGameToEventAsync(int id, GameDTO gameDto)
        {
            try
            {
                await _repo.AddGameToEventAsync(id, gameDto.Team1, gameDto.Team2);
                return gameDto;
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}