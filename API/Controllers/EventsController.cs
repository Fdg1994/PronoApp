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
                StartTimeEvent = e.StartTimeEvent,
                EndTimeEvent = e.EndTimeEvent,
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
                StartTimeEvent = eventEntity.StartTimeEvent,
                EndTimeEvent = eventEntity.EndTimeEvent,
                Games = eventEntity.Games.Select(m => m.Name).ToList()
            };
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> AddEventAsync(EventDTO eventDto)
        {
            try
            {
                await _repo.AddEventAsync(eventDto.Name,eventDto.StartTimeEvent,eventDto.EndTimeEvent,eventDto.LogoUrl);
                return eventDto;
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("{id}/{team1}/{team2}")]
        [AllowAnonymous] // TO DO: authorization for manager of specific company
        public async Task<ActionResult> AddGameToEventAsync(int id, string team1, string team2)
        {
            try
            {
                await _repo.AddGameToEventAsync(id, team1, team2);
                return Created("", null);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}