using AutoMapper;
using MediatR;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetFilteringSortingHandler : IRequestHandler<GetNewsFilteringSortingQuery, PaginationDTO<NewsDTO>>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public GetFilteringSortingHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<NewsDTO>> Handle(GetNewsFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            var news = newsRepository.GetFilterAndSorting(request.data);
            var newsDTOs = _mapper.Map<PaginationDTO<NewsDTO>>(news);

            return Task.FromResult(newsDTOs);
        }
    }
}
