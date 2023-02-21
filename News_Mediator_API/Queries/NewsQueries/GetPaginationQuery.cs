using MediatR;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Queries.NewsQueries
{
    public record class GetPaginationQuery(int page, float pageSize) : IRequest<PaginationDTO<NewsDTO>>;
}
