using AutoMapper;
using MediatR;
using News_Mediator_API.Commands.BookmarkCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class SaveHandler : IRequestHandler<SaveCommand, NewsDTO>
    {
        private readonly IBookmarkRepository bookmarkRepository;
        private readonly IMapper _mapper;

        public SaveHandler(IBookmarkRepository bookmarkRepository, IMapper mapper)
        {
            this.bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }

        public Task<NewsDTO> Handle(SaveCommand request, CancellationToken cancellationToken)
        {
            var news = bookmarkRepository.Save(request.id);
            var newsDTO = _mapper.Map<NewsDTO>(news);
            return Task.FromResult(newsDTO);
        }
    }
}
