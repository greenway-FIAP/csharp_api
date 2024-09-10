using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProductRepository : IProductRepository
{
    public Task<Product> AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int ProductId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(int ProductId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
