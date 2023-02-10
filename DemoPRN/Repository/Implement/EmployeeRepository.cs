﻿using DemoPRN.Models;

namespace DemoPRN.Repository.Implement
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MyDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployee(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
           Delete(employee);
        }

        public Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            return GetByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges).SingleOrDefault();
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
        {
            return GetByCondition(e => e.CompanyId.Equals(companyId), trackChanges).OrderBy(e => e.Name).ToList();
        }
    }
}