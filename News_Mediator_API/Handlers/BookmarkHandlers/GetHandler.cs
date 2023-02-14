using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.BookmarkQueries;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetHandler : IRequestHandler<GetQuery, List<News>>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public GetHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
        }

        public Task<List<News>> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookmarkRepository.GetAll());
        }
    }
}
