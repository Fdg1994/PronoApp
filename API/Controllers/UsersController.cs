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
        private readonly IUserEntityRepository _repo;

        public UsersController(IUserEntityRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<UserDTO>>> GetUsers()
        {
            var users = await _repo.GetUsersAsync();
            var userDtos = users.Select(u => new UserDTO
            {
                Username = u.UserName,
                Role = u.Role.ToString(),
                Points = u.Points,
                Company = u.Company.Name
            }).ToList();

            return Ok(userDtos);
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
                Points = user.Points,
                Company = user.Company.Name
            };
        }
    }
}