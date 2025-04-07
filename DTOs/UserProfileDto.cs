namespace UserProfileApi.DTOs;

using System.ComponentModel.DataAnnotations;

public class UserProfileDto
{
    public string Username { get; set; } = string.Empty;
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; } = string.Empty;
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? BirthDate { get; set; }
}
