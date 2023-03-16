using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper,IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IReadOnlyList<MemberDTO>>> GetUsersAsync()
        //{
        //    var users = await _repo.GetUsersAsync();
        //    var usersToReturn = _mapper.Map<IReadOnlyList<MemberDTO>>(users);

        //    return Ok(usersToReturn);
        //}

        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public async Task<ActionResult<MemberDTO>> GetUserAsync(int id)
        //{
        //    var user = await _repo.GetUserByIdAsync(id);

        //    return _mapper.Map<MemberDTO>(user);
        //}

        //[HttpGet("{id}/bets")]
        //[AllowAnonymous]
        //public async Task<ActionResult<IReadOnlyList<BetDTO>>> GetUserBetsAsync(int id)
        //{
        //    var bets = await _repo.GetBetsFromUserByIdAsync(id); //TODO: rename method in repo

        //    var betsToReturn = _mapper.Map<IReadOnlyList<BetDTO>>(bets);

        //    return Ok(betsToReturn);
        //}

        [HttpPost("{id}/addbet")]
        [AllowAnonymous]
        public async Task<ActionResult<Bet>> AddBetToUserAsync(int id, Bet bet)
        {
            try
            {
                await _userService.PlaceBet(id, bet.Game,(int) bet.PredictedOutcome, bet.BetAmount);
                return Created("", bet);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}