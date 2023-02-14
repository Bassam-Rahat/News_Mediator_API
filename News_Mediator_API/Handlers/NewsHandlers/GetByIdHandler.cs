using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.NewsQueries;
using News_Mediator_API.Queries.UserQueries;
using System.Data.Entity.Infrastructure.Design;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, News>
    {
        private readonly INewsRepository newsRepository;

        public GetByIdHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<News> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.GetById(request.id));
        }
    }
}
