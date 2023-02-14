using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.BookmarkQueries;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetBMFilteringSortingHandler : IRequestHandler<GetBMFilteringSortingQuery, PaginationDTO<News>>
    {
        private readonly IBookmarkRepository bookmarkRepository;

        public GetBMFilteringSortingHandler(IBookmarkRepository bookmarkRepository)
        {
            this.bookmarkRepository = bookmarkRepository;
        }

        public Task<PaginationDTO<News>> Handle(GetBMFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookmarkRepository.GetFilterAndSorting(request.data));
        }
    }
}
