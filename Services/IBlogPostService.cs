namespace UserProfileApi.Services;

using UserProfileApi.Models;
using UserProfileApi.DTOs;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
    Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(Guid authorId);
    Task<BlogPost> CreateAsync(BlogPostDto blogPostDto);
    Task<BlogPost?> UpdateAsync(Guid id, BlogPostDto blogPostDto);
    Task<bool> DeleteAsync(Guid id);
}
