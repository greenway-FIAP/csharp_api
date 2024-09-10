using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class AddressRepository : IAddressRepository
{
    public Task<Address> AddAddress(Address Address)
    {
        throw new NotImplementedException();
    }

    public void DeleteAddress(int AddressId)
    {
        throw new NotImplementedException();
    }

    public Task<Address> GetAddressById(int AddressId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Address>> GetAddresses()
    {
        throw new NotImplementedException();
    }

    public Task<Address> UpdateAddress(Address Address)
    {
        throw new NotImplementedException();
    }
}
