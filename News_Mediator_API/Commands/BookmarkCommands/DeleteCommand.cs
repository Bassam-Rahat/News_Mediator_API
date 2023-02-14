using MediatR;

namespace News_Mediator_API.Commands.BookmarkCommands
{
    public record class DeleteCommand(int id) : IRequest<string>;
}
