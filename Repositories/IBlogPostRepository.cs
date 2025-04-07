namespace UserProfileApi.Repositories;

using UserProfileApi.Models;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
    Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(Guid authorId);
    Task<BlogPost> CreateAsync(BlogPost blogPost);
    Task<BlogPost?> UpdateAsync(BlogPost blogPost);
    Task<bool> DeleteAsync(Guid id);
}
