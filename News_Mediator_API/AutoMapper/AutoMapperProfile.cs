﻿using AutoMapper;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Users;

namespace News_Mediator_API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<PaginationDTO<User>, PaginationDTO<UserDTO>>();

            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
            CreateMap<PaginationDTO<News>, PaginationDTO<NewsDTO>>();

            CreateMap<User, UserDataResponse>();
        //.ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.jwtToken));
        }
    }
}
