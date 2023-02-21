using MediatR;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Queries.UserQueries
{
    public record class GetFilteringSortingQuery(FilterData data) : IRequest<PaginationDTO<UserDTO>>;
}
