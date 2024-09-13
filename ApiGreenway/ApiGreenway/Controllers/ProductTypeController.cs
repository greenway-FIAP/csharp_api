using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/product-type")]
[ApiController]
public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypeController(IProductTypeRepository productTypeRepository)
    {
        this._productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
    {
        try
        {
            var productTypes = await _productTypeRepository.GetProductTypes();
            return Ok(productTypes);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{productTypeId:int}")]
    public async Task<ActionResult<ProductType>> GetProductTypeById(int productTypeId)
    {
        try
        {
            var productType = await _productTypeRepository.GetProductTypeById(productTypeId);
            if (productType == null)
            {
                return NotFound($"Tipo de Produto com o ID: {productTypeId}, não foi encontrado(a)!");
            }

            return Ok(productType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductType>> CreateProductType([FromBody] ProductType productType)
    {
        try
        {
            if (productType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProductType = await _productTypeRepository.AddProductType(productType);
            return CreatedAtAction(nameof(GetProductTypeById), new 
            { 
                productTypeId = createdProductType.id_product_type 
            }, createdProductType);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{productTypeId:int}")]
    public async Task<ActionResult<ProductType>> UpdateProductType(int productTypeId, [FromBody] ProductType productType)
    {
        try
        {
            if (productType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            productType.id_product_type = productTypeId;
            var updatedProductType = await _productTypeRepository.UpdateProductType(productType);

            if (updatedProductType == null)
            {
                return NotFound($"Tipo de Produto com o ID: {productTypeId}, não foi encontrado(a)!");
            }

            return Ok(updatedProductType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{productTypeId:int}")]
    public async Task<ActionResult<ProductType>> DeleteProductType(int productTypeId)
    {
        try
        {
            var deletedProductType = await _productTypeRepository.GetProductTypeById(productTypeId);

            if (deletedProductType == null)
            {
                return NotFound($"Tipo de Produto com o ID: {productTypeId}, não foi encontrado(a)!");
            }

            _productTypeRepository.DeleteProductType(productTypeId);

            return Ok("Tipo de Produto, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
