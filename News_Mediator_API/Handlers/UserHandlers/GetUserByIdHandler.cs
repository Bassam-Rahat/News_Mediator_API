using AutoMapper;
using MediatR;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Queries.UserQueries;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIDQuery, UserDTO>
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IRegisterRepository registerRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }

        public Task<UserDTO> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = _registerRepository.GetById(request.id);
            var userDTO = _mapper.Map<UserDTO>(user);

            return Task.FromResult(userDTO);
        }
    }
}
