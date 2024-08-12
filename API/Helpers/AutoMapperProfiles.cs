using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Photo, PhotoDto>();

        CreateMap<AppUser, MemberDto>()
            .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
        .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain)!.Url));
        // .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));

        CreateMap<MemberUpdateDto, AppUser>();
        
        CreateMap<RegisterDto, AppUser>();
        
        CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
        
        CreateMap<RegisterDto, AppUser>()
            .ForMember(dest => dest.DateOfBirth, 
                opt => opt.MapFrom<DateOnlyResolver>());
    }
}