namespace UserProfileApi.Services;

using UserProfileApi.Models;
using UserProfileApi.DTOs;
using UserProfileApi.Repositories;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        return await _repository.GetBySkuAsync(sku);
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await _repository.GetByCategoryAsync(category);
    }

    public async Task<Product> CreateAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Sku = productDto.Sku,
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Stock = productDto.Stock,
            Category = productDto.Category,
            Status = productDto.Status
        };

        return await _repository.CreateAsync(product);
    }

    public async Task<Product?> UpdateAsync(Guid id, ProductDto productDto)
    {
        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct == null)
            return null;

        existingProduct.Name = productDto.Name;
        existingProduct.Description = productDto.Description;
        existingProduct.Price = productDto.Price;
        existingProduct.Stock = productDto.Stock;
        existingProduct.Category = productDto.Category;
        existingProduct.Status = productDto.Status;

        return await _repository.UpdateAsync(existingProduct);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
