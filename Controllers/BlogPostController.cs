namespace UserProfileApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using UserProfileApi.Models;
using UserProfileApi.Services;
using UserProfileApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public BlogPostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetAll()
    {
        var posts = await _blogPostService.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> GetById(Guid id)
    {
        var post = await _blogPostService.GetByIdAsync(id);
        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetByAuthorId(Guid authorId)
    {
        var posts = await _blogPostService.GetByAuthorIdAsync(authorId);
        return Ok(posts);
    }

    [HttpPost]
    public async Task<ActionResult<BlogPost>> Create(BlogPostDto blogPostDto)
    {
        var post = await _blogPostService.CreateAsync(blogPostDto);
        return CreatedAtAction(nameof(GetById), new { id = post.Uuid }, post);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost>> Update(Guid id, BlogPostDto blogPostDto)
    {
        var post = await _blogPostService.UpdateAsync(id, blogPostDto);
        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _blogPostService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
