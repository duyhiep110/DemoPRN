namespace DemoPRN.Repository.Implement
{
    public class RepositoryManager : IRepositoryManager
    {

        private MyDbContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(MyDbContext repositoryContext, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }

        public ICompanyRepository CompanyRepository
        {
            get 
            {
                if ( _companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_repositoryContext);
                }
                return _companyRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                }
                return _employeeRepository;
            }
        }

        public async Task Save()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
