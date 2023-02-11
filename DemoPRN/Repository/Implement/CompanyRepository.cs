using System.ComponentModel.Design;
using DemoPRN.Models;

namespace DemoPRN.Repository.Implement
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(MyDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            return GetByCondition(c => ids.Contains(c.Id), trackChanges).ToList();
        }

        public Company GetCompany(Guid companyId, bool trackChanges)
        {
            return GetByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
        }

        public void UpdateCompany(Company company)
        {
            Update(company);
        }
    }
}