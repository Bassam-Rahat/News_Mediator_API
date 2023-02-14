using MediatR;

namespace News_Mediator_API.Commands.BookmarkCommands
{
    public record class SaveCommand(int id) : IRequest<string>;
}
