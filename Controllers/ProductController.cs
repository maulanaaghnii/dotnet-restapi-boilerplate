namespace UserProfileApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using UserProfileApi.Models;
using UserProfileApi.Services;
using UserProfileApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<Product>> GetBySku(string sku)
    {
        var product = await _service.GetBySkuAsync(sku);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string category)
    {
        var products = await _service.GetByCategoryAsync(category);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(ProductDto productDto)
    {
        try
        {
            var product = await _service.CreateAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Uuid }, product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Update(Guid id, ProductDto productDto)
    {
        try
        {
            var product = await _service.UpdateAsync(id, productDto);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
