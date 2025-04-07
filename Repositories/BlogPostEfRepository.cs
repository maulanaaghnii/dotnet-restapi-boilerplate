namespace UserProfileApi.Repositories;

using Microsoft.EntityFrameworkCore;
using UserProfileApi.Data;
using UserProfileApi.Models;

public class BlogPostEfRepository : IBlogPostRepository
{
    private readonly AppDbContext _context;

    public BlogPostEfRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts
            .Where(b => b.IsDeleted == 0)
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _context.BlogPosts
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Uuid == id && b.IsDeleted == 0);
    }

    public async Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(Guid authorId)
    {
        return await _context.BlogPosts
            .Where(b => b.AuthorId == authorId && b.IsDeleted == 0)
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
    {
        var existingPost = await _context.BlogPosts
            .FirstOrDefaultAsync(b => b.Uuid == blogPost.Uuid && b.IsDeleted == 0);

        if (existingPost == null)
            return null;

        existingPost.Title = blogPost.Title;
        existingPost.Content = blogPost.Content;
        existingPost.Status = blogPost.Status;
        existingPost.UpdatedAt = DateTime.UtcNow;

        if (blogPost.Status == "published" && existingPost.PublishedAt == null)
        {
            existingPost.PublishedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        return existingPost;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var blogPost = await _context.BlogPosts
            .FirstOrDefaultAsync(b => b.Uuid == id && b.IsDeleted == 0);

        if (blogPost == null)
            return false;

        blogPost.IsDeleted = 1;
        blogPost.DeletedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }
}
