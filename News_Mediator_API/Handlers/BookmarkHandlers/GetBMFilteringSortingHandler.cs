using AutoMapper;
using MediatR;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;
using News_Mediator_API.Queries.BookmarkQueries;

namespace News_Mediator_API.Handlers.BookmarkHandlers
{
    public class GetBMFilteringSortingHandler : IRequestHandler<GetBMFilteringSortingQuery, PaginationDTO<NewsDTO>>
    {
        private readonly IBookmarkRepository bookmarkRepository;
        private readonly IMapper _mapper;

        public GetBMFilteringSortingHandler(IBookmarkRepository bookmarkRepository, IMapper mapper)
        {
            this.bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }

        public Task<PaginationDTO<NewsDTO>> Handle(GetBMFilteringSortingQuery request, CancellationToken cancellationToken)
        {
            var news = bookmarkRepository.GetFilterAndSorting(request.data);
            var newsDTOs = _mapper.Map<PaginationDTO<NewsDTO>>(news);
            return Task.FromResult(newsDTOs);
        }
    }
}
