using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetFilteringSortingHandler : IRequestHandler<GetNewsFilteringSortingQuery, PaginationDTO<News>>
    {
        private readonly INewsRepository newsRepository;

        public GetFilteringSortingHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<PaginationDTO<News>> Handle(GetNewsFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.GetFilterAndSorting(request.data));
        }
    }
}
