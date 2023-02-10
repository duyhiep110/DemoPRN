using DemoPRN.Models;

namespace DemoPRN.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId,bool trackChanges);

        Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);

        void CreateEmployee(Guid companyId, Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
