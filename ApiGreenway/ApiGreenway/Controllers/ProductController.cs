using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        try
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<Product>> GetProductById(int productId)
    {
        try
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound($"Produto com o ID: {productId}, não foi encontrado(a)!");
            }

            return Ok(product);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        try
        {
            if (product == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProduct = await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new 
            { 
                productId = createdProduct.id_product 
            }, createdProduct);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{productId:int}")]
    public async Task<ActionResult<Product>> UpdateProduct(int productId, [FromBody] Product product)
    {
        try
        {
            if (product == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            product.id_product = productId;
            var updatedProduct = await _productRepository.UpdateProduct(product);

            if (updatedProduct == null)
            {
                return NotFound($"Produto com o ID: {productId}, não foi encontrado(a)!");
            }

            return Ok(updatedProduct);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult<Product>> DeleteProduct(int productId)
    {
        try
        {
            var deletedProduct = await _productRepository.GetProductById(productId);
            if (deletedProduct == null)
            {
                return NotFound($"Produto com o ID: {productId}, não foi encontrado(a)!");
            }

            _productRepository.DeleteProduct(productId);

            return Ok("Produto, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
