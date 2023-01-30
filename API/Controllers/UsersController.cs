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
        public async Task<ActionResult<UserEntity>> GetUser(int id)
        {
            return await _repo.GetUserByIdAsync(id);
        }
    }
}