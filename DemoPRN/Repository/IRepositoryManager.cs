namespace DemoPRN.Repository
{
    public interface IRepositoryManager
    {
        ICompanyRepository CompanyRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        Task Save();
    }
}
