using AutoMapper;
using News_Mediator_API.Models;

namespace News_Mediator_API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
