namespace UserProfileApi.Repositories;

using Microsoft.EntityFrameworkCore;
using UserProfileApi.Data;
using UserProfileApi.Models;

public class ProductEfRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductEfRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Where(p => p.IsDeleted == 0)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.Uuid == id && p.IsDeleted == 0);
    }

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.Sku == sku && p.IsDeleted == 0);
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await _context.Products
            .Where(p => p.Category == category && p.IsDeleted == 0)
            .ToListAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        var existingProduct = await _context.Products
            .FirstOrDefaultAsync(p => p.Uuid == product.Uuid && p.IsDeleted == 0);

        if (existingProduct == null)
            return null;

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;
        existingProduct.Category = product.Category;
        existingProduct.Status = product.Status;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingProduct;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Uuid == id && p.IsDeleted == 0);

        if (product == null)
            return false;

        product.IsDeleted = 1;
        product.DeletedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }
}
