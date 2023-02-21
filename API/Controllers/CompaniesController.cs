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
        public async Task<ActionResult<IReadOnlyList<CompanyEntity>>> GetCompanies()
        {
            return Ok(await _repo.GetCompaniesAsync());
        }
    }
}