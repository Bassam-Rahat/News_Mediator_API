using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.NewsQueries;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetPaginationHandler : IRequestHandler<GetPaginationQuery, PaginationDTO<NewsDTO>>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public GetPaginationHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<NewsDTO>> Handle(GetPaginationQuery request, CancellationToken cancellationToken)
        {
            var news= newsRepository.Get(request.page, request.pageSize);
            var newsDTOs = _mapper.Map<PaginationDTO<NewsDTO>>(news);

            //var paginationDto = new PaginationDTO<UserDTO>()
            //{
            //    Items = userDTOs
            //};

            return Task.FromResult(newsDTOs);
        }
    }
}
