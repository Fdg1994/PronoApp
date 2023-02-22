using API.DTOs;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CompaniesController:BaseApiController
    {
          private readonly DataContext _context;   
          private readonly ICompanyEntityRepository _repo;
        public CompaniesController(DataContext context, ICompanyEntityRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<CompanyDTO>>> GetCompanies()
        {
            var companies = await _repo.GetCompaniesAsync();
            var companyDtos = companies.Select(c => new CompanyDTO
            {
                Name = c.Name,
                PictureUrl = c.PictureUrl,
                Members = c.Members.Select(m => m.UserName).ToList()
            }).ToList();

            return Ok(companyDtos);
        }
    }
}