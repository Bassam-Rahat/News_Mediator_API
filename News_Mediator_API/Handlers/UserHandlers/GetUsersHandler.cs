using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        public GetUsersHandler(IRegisterRepository registerRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }

        public Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _registerRepository.Get();
            var userDTOs = _mapper.Map<List<UserDTO>>(users);

            return Task.FromResult(userDTOs);

        }
    }
}
