using Data.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserEntityRepository _repo;

        public UsersController(DataContext context, IUserEntityRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserEntity>>> GetUsers()
        {
            Console.WriteLine("at least we got here lol");
            return Ok(await _repo.GetUsersAsync());
        }
    }
}