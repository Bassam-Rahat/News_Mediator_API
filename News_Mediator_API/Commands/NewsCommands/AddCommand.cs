using MediatR;
using News_Mediator_API.Models;

namespace News_Mediator_API.Commands.NewsCommands
{
    public record class AddCommand : IRequest<NewsDTO>
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
