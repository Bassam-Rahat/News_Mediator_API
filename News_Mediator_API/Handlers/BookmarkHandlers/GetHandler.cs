using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.BookmarkQueries;
using News_Mediator_API.Repository;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetHandler : IRequestHandler<GetQuery, List<NewsDTO>>
    {
        private readonly IBookmarkRepository bookmarkRepository;
        private readonly IMapper _mapper;

        public GetHandler(IBookmarkRepository bookmarkRepository, IMapper mapper)
        {
            this.bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }

        public Task<List<NewsDTO>> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var news = bookmarkRepository.GetAll();
            var newsDTOs = _mapper.Map<List<NewsDTO>>(news);

            return Task.FromResult(newsDTOs);
        }
    }
}
