using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [MaxLength(100)]
    public required string UserName { get; set; }
    
    public required string Password { get; set; }
}