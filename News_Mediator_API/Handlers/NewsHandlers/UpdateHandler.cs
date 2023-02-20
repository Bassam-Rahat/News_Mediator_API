using AutoMapper;
using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Repository;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, NewsDTO>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper _mapper;

        public UpdateHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            _mapper = mapper;
        }

        public Task<NewsDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            //return Task.FromResult(newsRepository.Update(request.id, request.updateRequest));

            var news = _mapper.Map<News>(request);
            var updateNews = newsRepository.Update(request.id, news);
            var newsDTO = _mapper.Map<NewsDTO>(updateNews);

            return Task.FromResult(newsDTO);
        }
    }
}
