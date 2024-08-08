using API.Entities;

namespace API.DTOs;

public class SeedUserDto
{
    // Required properties
    public string UserName { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte[0];
    public string KnownAs { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    // Optional properties
    public string? Introduction { get; set; }
    public string? Interests { get; set; }
    public string? LookingFor { get; set; }

    // Collection property
    public List<Photo> Photos { get; set; } = new List<Photo>();
}