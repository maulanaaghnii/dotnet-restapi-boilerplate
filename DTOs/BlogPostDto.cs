namespace UserProfileApi.DTOs;

using System.ComponentModel.DataAnnotations;

public class BlogPostDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = string.Empty;

    public string Status { get; set; } = "draft";

    public Guid AuthorId { get; set; }
}
