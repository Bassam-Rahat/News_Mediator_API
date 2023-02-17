using AutoMapper;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

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
        }
    }
}
