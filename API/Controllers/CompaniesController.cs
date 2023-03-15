using API.DTOs;
using AutoMapper;
using Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CompaniesController : BaseApiController
    {
        private readonly ICompanyEntityRepository _repo;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyEntityRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<CompanyDTO>>> GetCompaniesAsync()
        {
            var companies = await _repo.GetCompaniesAsync();
            var companiesToReturn = _mapper.Map<IReadOnlyList<CompanyDTO>>(companies);

            return Ok(companiesToReturn);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CompanyDTO>> GetCompanyByIdAsync(int id)
        {
            var company = await _repo.GetCompanyByIdAsync(id);

            return _mapper.Map<CompanyDTO>(company);
        }

        [HttpPost("{id}/{name}/{password}")]
        [AllowAnonymous] // TO DO: authorization for manager of specific company
        public async Task<ActionResult> AddUserToCompanyAsync(int id, string name, string password)
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