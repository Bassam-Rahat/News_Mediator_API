using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.NewsQueries
{
    public record class GetNewsFilteringSortingQuery(FilterData data) : IRequest<PaginationDTO<NewsDTO>>;
}
