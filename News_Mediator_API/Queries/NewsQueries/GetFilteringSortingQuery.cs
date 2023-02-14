using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.NewsQueries
{
    public record class GetFilteringSortingQuery(int page, string columnName, string find, string sortOrder) : IRequest<PaginationDTO<News>>;
}
