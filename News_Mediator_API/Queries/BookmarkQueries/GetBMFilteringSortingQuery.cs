using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.BookmarkQueries
{
    public record class GetBMFilteringSortingQuery(FilterData data) : IRequest<PaginationDTO<NewsDTO>>;
}
