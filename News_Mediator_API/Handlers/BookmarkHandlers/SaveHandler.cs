using MediatR;
using News_Mediator_API.Commands.BookmarkCommands;
using News_Mediator_API.Interfaces;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class SaveHandler : IRequestHandler<SaveCommand, string>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public SaveHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
        }

        public Task<string> Handle(SaveCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookmarkRepository.Save(request.id));
        }
    }
}
