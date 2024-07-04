using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.User.Requests;
using ECommerceAPI.Dtos.User.Responses;
namespace ECommerceAPI.MappingProfiles
{
    public class UserMappings: Profile
    {
        public UserMappings()
        {
            CreateMap<User,UserResponseDto>().ReverseMap();
            CreateMap<User,UpdateUserRequestDto>().ReverseMap();
        }
    }
}
