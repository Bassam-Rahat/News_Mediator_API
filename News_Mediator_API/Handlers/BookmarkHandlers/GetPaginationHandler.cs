using AutoMapper;
using MediatR;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Queries.BookmarkQueries;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetPaginationHandler : IRequestHandler<GetBookmarkPaginationQuery, PaginationDTO<NewsDTO>>
    {
        private readonly IBookmarkRepository bookmarkRepository;
        private readonly IMapper _mapper;

        public GetPaginationHandler(IBookmarkRepository bookmarkRepository, IMapper mapper)
        {
            this.bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<NewsDTO>> Handle(GetBookmarkPaginationQuery request, CancellationToken cancellationToken)
        {
            var news = bookmarkRepository.Get(request.page, request.pageSize);
            var newsDTOs = _mapper.Map<PaginationDTO<NewsDTO>>(news);

            return Task.FromResult(newsDTOs);
        }
    }
}
