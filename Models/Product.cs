namespace UserProfileApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("tblproduct")]
[Index(nameof(Sku), Name = "SKU", IsUnique = true)]
public class Product
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; } = Guid.NewGuid();

    [Column("sku", TypeName = "varchar(50)")]
    [Required(ErrorMessage = "SKU is required")]
    public string Sku { get; set; } = string.Empty;

    [Column("name", TypeName = "varchar(200)")]
    [Required(ErrorMessage = "Product name is required")]
    public string Name { get; set; } = string.Empty;

    [Column("description", TypeName = "longtext")]
    public string? Description { get; set; }

    [Column("price", TypeName = "decimal(10,2)")]
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Column("stock", TypeName = "int")]
    [Required(ErrorMessage = "Stock is required")]
    public int Stock { get; set; }

    [Column("category", TypeName = "varchar(100)")]
    public string? Category { get; set; }

    [Column("status", TypeName = "varchar(20)")]
    public string Status { get; set; } = "active"; // active, inactive, discontinued

    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Column("is_deleted", TypeName = "int(1)")]
    public int IsDeleted { get; set; } = 0;

    [Column("deleted_at", TypeName = "datetime(6)")]
    public DateTime? DeletedAt { get; set; }
}
