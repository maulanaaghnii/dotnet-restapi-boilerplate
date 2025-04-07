namespace UserProfileApi.Services;

using UserProfileApi.Models;
using UserProfileApi.DTOs;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product?> GetBySkuAsync(string sku);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    Task<Product> CreateAsync(ProductDto productDto);
    Task<Product?> UpdateAsync(Guid id, ProductDto productDto);
    Task<bool> DeleteAsync(Guid id);
}
