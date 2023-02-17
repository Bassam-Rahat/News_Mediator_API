using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.NewsQueries;
using News_Mediator_API.Queries.UserQueries;
using System.Data.Entity.Infrastructure.Design;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, NewsDTO>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<NewsDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var news = newsRepository.GetById(request.id);
            var newsDTO = _mapper.Map<NewsDTO>(news);

            return Task.FromResult(newsDTO);
        }
    }
}
