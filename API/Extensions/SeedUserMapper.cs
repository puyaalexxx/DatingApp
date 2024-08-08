using API.DTOs;
using API.Entities;

namespace API.Extensions;

public class SeedUserMapper
{
    public static AppUser ToAppUser(SeedUserDto dto)
    {
        return new AppUser
        {
            UserName = dto.UserName.ToLower(),
            PasswordHash = dto.PasswordHash,
            PasswordSalt = dto.PasswordSalt,
            KnownAs = dto.KnownAs,
            Gender = dto.Gender,
            City = dto.City,
            Country = dto.Country,
            Introduction = dto.Introduction,
            Interests = dto.Interests,
            LookingFor = dto.LookingFor,
            Photos = dto.Photos
        };
    }
}