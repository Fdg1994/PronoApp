using API.DTOs;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CompaniesController:BaseApiController
    {  
        private readonly ICompanyEntityRepository _repo;
        public CompaniesController(ICompanyEntityRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<CompanyDTO>>> GetCompaniesAsync()
        {
            var companies = await _repo.GetCompaniesAsync();
            var companyDtos = companies.Select(c => new CompanyDTO
            {
                Id = c.Id,
                Name = c.Name,
                PictureUrl = c.PictureUrl,
                Members = c.Members.Select(m => m.UserName).ToList()
            }).ToList();

            return Ok(companyDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CompanyDTO>> GetCompanyByIdAsync(int id)
        {
            var company = await _repo.GetCompanyByIdAsync(id);

            return new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                PictureUrl = company.PictureUrl,
                Members = company.Members.Select(m => m.UserName).ToList()
            };
        }

        [HttpPost("{id}/{name}/{password}")]
        [AllowAnonymous] // TO DO: authorization for manager of specific company
        public async Task<ActionResult> AddUserToCompanyAsync(int id,string name,string password)
        {
            try
            {
                await _repo.AddUserToCompanyAsync(id, name, password);
                return Created("", null);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}