using AutoMapper;
using DemoPRN.Dtos.Company;
using DemoPRN.Logger;
using DemoPRN.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoPRN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        private readonly IRepositoryManager _repositoryManger;
        private readonly IMapper _mapper;

        public CompaniesController(IRepositoryManager repositoryManger, IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }



        // GET: api/<CompaniesController>
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _repositoryManger.CompanyRepository.GetAllCompanies(false);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
        }

        // GET api/<CompaniesController>/5
        [HttpGet("id")]
        public IActionResult GetCompany([FromQuery] Guid id)
        {
            var company = _repositoryManger.CompanyRepository.GetCompany(id, false);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CompanyDto>(company));
        }

        [HttpGet("cid")]
        public IActionResult GetCompanyByHeader([FromHeader(Name = "cid")] Guid id)
        {
            var company = _repositoryManger.CompanyRepository.GetCompany(id, false);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CompanyDto>(company));
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Company is null here");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var company = _mapper.Map<Models.Company>(dto);
            _repositoryManger.CompanyRepository.CreateCompany(company);
            _repositoryManger.Save();

            return NoContent();
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(Guid id, [FromForm] CompanyForUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Company is null here");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var company = _repositoryManger.CompanyRepository.GetCompany(id, true);
            if (company == null)
            {
                return NotFound("No Company is founded");
            }
             _mapper.Map(dto,company);
            _repositoryManger.CompanyRepository.UpdateCompany(company);
            _repositoryManger.Save();
            return NoContent();
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {

            var company = _repositoryManger.CompanyRepository.GetCompany(id, true);
            if (company == null)
            {
                return NotFound();
            }
            _repositoryManger.CompanyRepository.DeleteCompany(company);
            _repositoryManger.Save();
            return NoContent();
        }
    }
}
