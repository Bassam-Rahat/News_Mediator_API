using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.BookmarkQueries;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetPaginationHandler : IRequestHandler<GetBookmarkPaginationQuery, PaginationDTO<News>>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public GetPaginationHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
        }

        public Task<PaginationDTO<News>> Handle(GetBookmarkPaginationQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookmarkRepository.Get(request.page, request.pageSize));
        }
    }
}
