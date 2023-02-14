using MediatR;

namespace News_Mediator_API.Commands.UserCommands
{
    public record DeleteUserCommand(int id) : IRequest<string>;
}
