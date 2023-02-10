using DemoPRN.Dtos.Employee;

namespace DemoPRN.Dtos.Company
{
    public class CompanyForCreateDto : CompanyForManipulationDto
    {
        public IEnumerable<EmployeeForCreateDto> Employees { get; set; }
    }
}
