using MediatR;

namespace News_Mediator_API.Commands.NewsCommands
{
    public record class DeleteCommand(int id) : IRequest<string>;
}
