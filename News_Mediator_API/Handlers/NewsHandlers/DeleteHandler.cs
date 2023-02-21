using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Repository.Interfaces;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, string>
    {
        private readonly INewsRepository newsRepository;

        public DeleteHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.Delete(request.id));
        }
    }
}
