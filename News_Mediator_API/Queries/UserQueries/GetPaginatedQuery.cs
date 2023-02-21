using MediatR;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Queries.UserQueries
{
    public record class GetPaginatedQuery(int page, float pageSize) : IRequest<PaginationDTO<UserDTO>>;
}
