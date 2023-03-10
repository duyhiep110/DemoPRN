using DemoPRN.Models;

namespace DemoPRN.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);

        Company GetCompany(Guid companyId, bool trackChanges);

        void CreateCompany(Company company);

        void UpdateCompany(Company company);

        IEnumerable<Company> GetByIds(IEnumerable<Guid> ids,bool trackChanges);

        void DeleteCompany(Company company);
    }
}
