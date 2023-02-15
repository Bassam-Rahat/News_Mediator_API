using AutoMapper;
using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Repository;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class AddHandler : IRequestHandler<AddCommand, string>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public AddHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<string> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var news = _mapper.Map<News>(request.news);
            var addNews = (newsRepository.Add(news));

            return Task.FromResult(addNews);
        }
    }
}
