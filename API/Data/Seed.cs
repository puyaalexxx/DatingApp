using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.DTOs;
using API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {

        if (await context.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var users = JsonSerializer.Deserialize<List<SeedUserDto>>(userData, options);
        
        if (users is null)
        {
            return;
        }
        
        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();
            
            // Create AppUser from SeedUserDto
            var userMapped = SeedUserMapper.ToAppUser(user);

            userMapped.UserName = userMapped.UserName.ToLower();
            userMapped.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$word"));
            userMapped.PasswordSalt = hmac.Key;

            context.Users.Add(userMapped);
        }

        await context.SaveChangesAsync();
    }
}