using DemoPRN.Dtos.Employee;

namespace DemoPRN.Dtos.Company
{
    public class CompanyForUpdateDto : CompanyForManipulationDto
    {
        public IEnumerable<EmployeeForUpdateDto> Employees { get; set; }
    }
}
