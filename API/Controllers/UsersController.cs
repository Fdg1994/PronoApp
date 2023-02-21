using API.DTOs;
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
        private readonly DataContext _context;
        private readonly IUserEntityRepository _repo;

        public UsersController(DataContext context, IUserEntityRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<UserEntity>>> GetUsers()
        {
            return Ok(await _repo.GetUsersAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            
            return new UserDTO
            {
                Username = user.UserName,
                Role = user.Role.ToString(),
                Points = user.Points
            };
        }
    }
}