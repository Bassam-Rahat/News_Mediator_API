using MediatR;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;

namespace News_Mediator_API.Queries.UserQueries
{
    public record class GetFilteringSortingQuery(FilterData data) : IRequest<PaginationDTO<User>>;
}
