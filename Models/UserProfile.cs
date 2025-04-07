namespace UserProfileApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tbluserprofile")]
[Index(nameof(Username), Name = "UserName")]
[Index(nameof(Email), Name = "Email", IsUnique = true)]
public class UserProfile
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; } = Guid.NewGuid();
    
    [Column("username", TypeName = "varchar(100)")]
    public string Username { get; set; } = string.Empty;
    
    [Column("email", TypeName = "varchar(150)")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; } = string.Empty;
    
    [Column("first_name", TypeName = "varchar(50)")]
    public string? FirstName { get; set; }
    
    [Column("last_name", TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    
    [Column("description", TypeName = "longtext")]
    public string? Description { get; set; }
    
    [Column("birth_date", TypeName = "varchar(20)")]
    public string? BirthDate { get; set; }

    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("is_deleted", TypeName = "int(1)")]
    public int IsDeleted { get; set; } = 0;
    
    [Column("deleted_at", TypeName = "datetime(6)")]
    public DateTime? DeletedAt { get; set; }
}
