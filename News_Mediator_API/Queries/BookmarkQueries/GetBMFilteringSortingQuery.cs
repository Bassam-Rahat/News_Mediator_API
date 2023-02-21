using MediatR;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Queries.BookmarkQueries
{
    public record class GetBMFilteringSortingQuery(FilterData data) : IRequest<PaginationDTO<NewsDTO>>;
}
