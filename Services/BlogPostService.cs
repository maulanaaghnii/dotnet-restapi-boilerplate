namespace UserProfileApi.Services;

using UserProfileApi.Models;
using UserProfileApi.DTOs;
using UserProfileApi.Repositories;

public class BlogPostService : IBlogPostService
{
    private readonly IBlogPostRepository _repository;

    public BlogPostService(IBlogPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(Guid authorId)
    {
        return await _repository.GetByAuthorIdAsync(authorId);
    }

    public async Task<BlogPost> CreateAsync(BlogPostDto blogPostDto)
    {
        var blogPost = new BlogPost
        {
            Title = blogPostDto.Title,
            Content = blogPostDto.Content,
            Status = blogPostDto.Status,
            AuthorId = blogPostDto.AuthorId
        };

        return await _repository.CreateAsync(blogPost);
    }

    public async Task<BlogPost?> UpdateAsync(Guid id, BlogPostDto blogPostDto)
    {
        var existingPost = await _repository.GetByIdAsync(id);
        if (existingPost == null)
            return null;

        existingPost.Title = blogPostDto.Title;
        existingPost.Content = blogPostDto.Content;
        existingPost.Status = blogPostDto.Status;

        return await _repository.UpdateAsync(existingPost);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
