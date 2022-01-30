using AutoMapper;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;

namespace Dashboard.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // sorce -> target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
