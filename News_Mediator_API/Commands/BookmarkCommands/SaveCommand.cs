using MediatR;
using News_Mediator_API.Repository.Models;

namespace News_Mediator_API.Commands.BookmarkCommands
{
    public record class SaveCommand(int id) : IRequest<NewsDTO>;
}
