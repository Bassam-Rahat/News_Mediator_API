using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, News>
    {
        private readonly INewsRepository newsRepository;

        public UpdateHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<News> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.Update(request.id, request.updateRequest));
        }
    }
}
