using AutoMapper;
using MediatR;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Handlers.NewsHandlers
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<NewsDTO>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        public GetAllHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;   
        }

        public Task<List<NewsDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var news = _newsRepository.GetAll();
            var newsDTOs = _mapper.Map<List<NewsDTO>>(news);

            return Task.FromResult(newsDTOs);
        }
    }
}
