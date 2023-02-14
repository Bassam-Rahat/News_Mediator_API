using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<News>>
    {
        private readonly INewsRepository _newsRepository;

        public GetAllHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public Task<List<News>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_newsRepository.GetAll());
        }
    }
}
