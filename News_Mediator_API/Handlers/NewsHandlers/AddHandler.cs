using MediatR;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class AddHandler : IRequestHandler<AddCommand, string>
    {
        private readonly INewsRepository newsRepository;

        public AddHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public Task<string> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(newsRepository.Add(request.news));
        }
    }
}
