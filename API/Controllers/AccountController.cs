using System.Security.Cryptography;
using System.Text;
using API.DTOs;
using API.Interface;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(DataContext context,ITokenService tokenService,IMapper mapper)
        {
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("register")]

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username is taken.");

            if (await CompanyExists(registerDTO.CompanyName)) return BadRequest("Company already exists.");

            using var hmac = new HMACSHA512();

            var company = new CompanyEntity
            {
                Name = registerDTO.CompanyName.ToLower(),
                Members = new List<UserEntity>()
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            

            var user = new UserEntity
            {
                UserName = registerDTO.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key,
                CompanyEntityId = company.Id,
                Company = company
            };

            company.Members.Add(user);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Username = user.UserName,
                Role = user.Role.ToString().ToLower(),
                Points = user.Points,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.Username);
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == user.CompanyEntityId);

            if (user == null) return Unauthorized("User does not exist");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role.ToString(),
                Points = user.Points,
                CompanyId = user.CompanyEntityId,
                Company = _mapper.Map<CompanyDTO>(company),
                CompanyRole = user.CompanyRole.ToString()        
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        private async Task<bool> CompanyExists(string name)
        {
            return await _context.Companies.AnyAsync(x => x.Name == name.ToLower());
        }
    }
}