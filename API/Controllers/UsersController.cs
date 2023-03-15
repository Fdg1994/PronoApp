using API.DTOs;
using AutoMapper;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserEntityRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserEntityRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<MemberDTO>>> GetUsersAsync()
        {
            var users = await _repo.GetUsersAsync();
            var usersToReturn = _mapper.Map<IReadOnlyList<MemberDTO>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MemberDTO>> GetUserAsync(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);

            return _mapper.Map<MemberDTO>(user);
        }

        [HttpGet("{id}/bets")]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<BetDTO>>> GetUserBetsAsync(int id)
        {
            var bets = await _repo.GetBetsFromUserByIdAsync(id); //TODO: rename method in repo

            var betsToReturn = _mapper.Map<IReadOnlyList<BetDTO>>(bets);

            return Ok(betsToReturn);
        }

        [HttpPost("{id}/addbet")]
        [AllowAnonymous]
        public async Task<ActionResult<BetDTO>> AddBetToUserAsync(int id, BetDTO betDto)
        {
            try
            {
                await _repo.AddBetToUserAsync(id, betDto.GameEntityId, betDto.BetAmount, betDto.PredictedOutcome);
                return betDto;
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}