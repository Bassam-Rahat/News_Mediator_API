using MediatR;
using News_Mediator_API.Commands.BookmarkCommands;
using News_Mediator_API.Interfaces;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, string>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public DeleteHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
        }

        public Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookmarkRepository.Delete(request.id));
        }
    }
}
