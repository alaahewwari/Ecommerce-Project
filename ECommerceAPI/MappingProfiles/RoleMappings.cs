using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Role.Requests;
using ECommerceAPI.Dtos.Role.Responses;
namespace ECommerceAPI.MappingProfiles
{
    public class RoleMappings : Profile
    {
        public RoleMappings()
        {
            CreateMap<Role, RoleResponseDto>().ReverseMap();
            CreateMap<RoleRequestDto,Role>().ReverseMap();
        }
    }
}
