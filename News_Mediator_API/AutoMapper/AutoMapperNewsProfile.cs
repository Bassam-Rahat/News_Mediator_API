using AutoMapper;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Domain.Models;

namespace News_Mediator_API.AutoMapper
{
    public class AutoMapperNewsProfile : Profile
    {
        public AutoMapperNewsProfile()
        {

            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
            CreateMap<PaginationDTO<News>, PaginationDTO<NewsDTO>>();
            CreateMap<AddCommand, News>();
            CreateMap<UpdateCommand, News>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
