using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiGreenway.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly dbContext _dbContext;

    public AddressRepository(dbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<Address> AddAddress(Address address)
    {
        var addressBd = await _dbContext.Addresses.AddAsync(address);
        await _dbContext.SaveChangesAsync();
        return addressBd.Entity;
    }

    public async Task<IEnumerable<Address>> GetAddresses()
    {
        return await _dbContext.Addresses.ToListAsync();
    }

    public async Task<Address> GetAddressById(int addressId)
    {
        return await _dbContext.Addresses.FirstOrDefaultAsync(d => d.id_address == addressId);
    }

    public async Task<Address> UpdateAddress(Address address)
    {
        var existingAddress = await _dbContext.Addresses.FirstOrDefaultAsync(d => d.id_address == address.id_address);
        if (existingAddress == null)
        {
            return null; // Retorna null se o Address não for encontrado
        }

        // Atualiza o nome da rua
        existingAddress.ds_street = address.ds_street;
        existingAddress.ds_zip_code = address.ds_zip_code;
        existingAddress.ds_number = address.ds_number;
        existingAddress.ds_uf = address.ds_uf;
        existingAddress.ds_neighborhood = address.ds_neighborhood;
        existingAddress.ds_city = address.ds_city;

        address.dt_updated_at = DateTime.Now;

        await _dbContext.SaveChangesAsync();
        return existingAddress;
    }

    public async void DeleteAddress(int addressId)
    {
        var result = await _dbContext.Addresses.FirstOrDefaultAsync(d => d.id_address == addressId);
        if (result != null)
        {
            _dbContext.Addresses.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
