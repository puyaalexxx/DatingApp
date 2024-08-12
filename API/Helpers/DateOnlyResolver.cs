using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class DateOnlyResolver : IValueResolver<RegisterDto, AppUser, DateOnly>
{
    public DateOnly Resolve(RegisterDto source, AppUser destination, DateOnly destMember, ResolutionContext context)
    {
        DateTime dateTime = DateTime.Parse(source.DateOfBirth!, null, System.Globalization.DateTimeStyles.RoundtripKind);

        // Step 2: Convert DateTime to DateOnly
        DateOnly dateOnly = DateOnly.FromDateTime(dateTime);

        return dateOnly;
    }
}