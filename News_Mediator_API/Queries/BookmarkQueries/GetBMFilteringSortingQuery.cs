using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.BookmarkQueries
{
    public record class GetBMFilteringSortingQuery(int page, string columnName, string find, string sortOrder) : IRequest<PaginationDTO<News>>;
}
