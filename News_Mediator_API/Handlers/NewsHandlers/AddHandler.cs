using AutoMapper;
using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Domain.Models;
using News_Mediator_API.Repository;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class AddHandler : IRequestHandler<AddCommand, NewsDTO>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public AddHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<NewsDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var news = _mapper.Map<News>(request);
            var add = (newsRepository.Add(news));
            var addNews = _mapper.Map<NewsDTO>(add);

            return Task.FromResult(addNews);
        }
    }
}
