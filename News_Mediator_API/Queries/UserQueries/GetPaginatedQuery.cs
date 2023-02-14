using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.UserQueries
{
    public record class GetPaginatedQuery(int page) : IRequest<PaginationDTO<User>>;
}
