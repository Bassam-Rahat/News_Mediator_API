using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.NewsQueries;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetPaginationHandler : IRequestHandler<GetPaginationQuery, PaginationDTO<News>>
    {
        private readonly INewsRepository newsRepository;

        public GetPaginationHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<PaginationDTO<News>> Handle(GetPaginationQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.Get(request.page));
        }
    }
}
