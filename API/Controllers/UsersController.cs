using API.DTOs;
using AutoMapper;
using Data.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
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
        public async Task<ActionResult<IReadOnlyList<MemberDTO>>> GetUsers()
        {
            var users = await _repo.GetUsersAsync();
            var usersToReturn = _mapper.Map<IReadOnlyList<MemberDTO>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MemberDTO>> GetUser(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);

            return _mapper.Map<MemberDTO>(user);
        }
    }
}