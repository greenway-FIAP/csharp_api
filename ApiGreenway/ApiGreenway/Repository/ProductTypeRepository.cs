using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProductTypeRepository : IProductTypeRepository
{
    public Task<ProductType> AddProductType(ProductType productType)
    {
        throw new NotImplementedException();
    }

    public void DeleteProductType(int ProductTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductType> GetProductTypeById(int ProductTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductType>> GetProductTypes()
    {
        throw new NotImplementedException();
    }

    public Task<ProductType> UpdateProductType(ProductType productType)
    {
        throw new NotImplementedException();
    }
}
