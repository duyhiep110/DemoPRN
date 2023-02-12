using AutoMapper;
using DemoPRN.Dtos.Company;
using DemoPRN.Dtos.Employee;
using DemoPRN.Models;
using DemoPRN.Repository;
using DemoPRN.Repository.Implement;
using Microsoft.AspNetCore.Mvc;

namespace DemoPRN.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId) {
            var company = _repository.CompanyRepository.GetCompany(companyId, trackChanges: false);
            if(company == null)
            {
                return NotFound(); 
            }
            var employeesFromDb = _repository.EmployeeRepository.GetEmployees(companyId, trackChanges: false);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return Ok(employeesDto);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId,[FromBody] EmployeeForCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("EmployeeForCreateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var company = _repository.CompanyRepository.GetCompany(companyId, false);
            if(company == null)
            {
                return NotFound();
            }
            var employeeEntity = _mapper.Map<Employee>(dto);
            _repository.EmployeeRepository.CreateEmployee(companyId, employeeEntity);
            _repository.Save();
            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id = employeeToReturn.Id},employeeToReturn);
        }

        [HttpGet("{id}", Name = " GetEmployeeForCompany")]
        public IActionResult GetEmployeesForCompany(Guid companyId,Guid id) {
            var company = _repository.CompanyRepository.GetCompany(companyId,trackChanges: false);
            if(company == null)
            {
                return NotFound();
            }
            var employeeDb = _repository.EmployeeRepository.GetEmployee(companyId, id, trackChanges: false);
            if(employeeDb == null)
            {
                return NotFound();
            }
            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id) {
            var company = _repository.CompanyRepository.GetCompany(companyId, trackChanges: false);
            if(company!= null)
            {
                return NotFound();
            }
            var employeeForCompany = _repository.EmployeeRepository.GetEmployee(companyId,id,trackChanges: false);
            if(employeeForCompany == null) { 
                return NotFound();
            }
            _repository.EmployeeRepository.DeleteEmployee(employeeForCompany);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("EmployeeForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var company = _repository.CompanyRepository.GetCompany(id, false);
            if (company == null)
            {
                return NotFound("No Company is founded");
            }
            var employeeeEntity = _repository.EmployeeRepository.GetEmployee(companyId, id, true);
            if (employeeeEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, employeeeEntity);
            _repository.Save();
            return NoContent();
        }
    }
}

