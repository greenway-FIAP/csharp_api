using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class CompanyRepresentativeRepository : ICompanyRepresentativeRepository
{
    public Task<CompanyRepresentative> AddCompanyRepresentative(CompanyRepresentative CompanyRepresentative)
    {
        throw new NotImplementedException();
    }

    public void DeleteCompanyRepresentative(int CompanyRepresentativeId)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyRepresentative> GetCompanyRepresentativeById(int CompanyRepresentativeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CompanyRepresentative>> GetCompanyRepresentatives()
    {
        throw new NotImplementedException();
    }

    public Task<CompanyRepresentative> UpdateCompanyRepresentative(CompanyRepresentative CompanyRepresentative)
    {
        throw new NotImplementedException();
    }
}
