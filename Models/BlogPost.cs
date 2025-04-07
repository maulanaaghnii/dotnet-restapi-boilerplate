namespace UserProfileApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tblblogpost")]
public class BlogPost
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; } = Guid.NewGuid();

    [Column("title", TypeName = "varchar(200)")]
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Column("content", TypeName = "longtext")]
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = string.Empty;

    [Column("author_id")]
    public Guid AuthorId { get; set; }

    [Column("status", TypeName = "varchar(20)")]
    public string Status { get; set; } = "draft";

    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Column("published_at", TypeName = "datetime(6)")]
    public DateTime? PublishedAt { get; set; }

    [Column("is_deleted", TypeName = "int(1)")]
    public int IsDeleted { get; set; } = 0;

    [Column("deleted_at", TypeName = "datetime(6)")]
    public DateTime? DeletedAt { get; set; }

    // Navigation property
    [ForeignKey("AuthorId")]
    public UserProfile? Author { get; set; }
}
