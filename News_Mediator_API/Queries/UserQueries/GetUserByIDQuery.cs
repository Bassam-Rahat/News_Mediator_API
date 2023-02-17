using MediatR;
using News_Mediator_API.Models;

namespace News_Mediator_API.Queries.UserQueries
{
    public record GetUserByIDQuery(int id) : IRequest<UserDTO>;
}
