using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class CompanyRepository : ICompanyRepository
{
    public Task<Company> AddCompany(Company Company)
    {
        throw new NotImplementedException();
    }

    public void DeleteCompany(int CompanyId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company>> GetCompanies()
    {
        throw new NotImplementedException();
    }

    public Task<Company> GetCompanyById(int CompanyId)
    {
        throw new NotImplementedException();
    }

    public Task<Company> UpdateCompany(Company Company)
    {
        throw new NotImplementedException();
    }
}
