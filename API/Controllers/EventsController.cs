using System.Diagnostics;
using API.DTOs;
using AutoMapper;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class EventsController : BaseApiController
    {
        private readonly IEventEntityRepository _repo;
        private readonly IMapper _mapper;

        public EventsController(IEventEntityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous] //TO DO: Authorization
        public async Task<ActionResult<IReadOnlyList<EventDTO>>> GetEventsAsync()
        {
            var events = await _repo.GetEventsAsync();
            var eventsToReturn = _mapper.Map<IReadOnlyList<EventDTO>>(events);

            return Ok(eventsToReturn);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> GetEventByIdAsync(int id)
        {
            var eventToReturn = await _repo.GetEventByIdAsync(id);

            if (eventToReturn == null)
            {
                return NotFound();
            }

            return _mapper.Map<EventDTO>(eventToReturn);
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult<EventDTO>> AddEventAsync(EventDTO eventDto)
        {
            try
            {
                await _repo.AddEventAsync(eventDto.Name, eventDto.LogoUrl);
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
                await _repo.AddGameToEventAsync(id, gameDto.Team1, gameDto.Team2,gameDto.StartTimeGame,gameDto.EndTimeGame);
                return gameDto;
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{id}/delete")]
        [AllowAnonymous]

        public async Task<IActionResult> DeleteEventByIdAsync(int id)
        {
            try
            {
                await _repo.DeleteEventByIdAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}