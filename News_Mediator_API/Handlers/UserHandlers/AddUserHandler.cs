using AutoMapper;
using MediatR;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserDTO>
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        public AddUserHandler(IRegisterRepository registerRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }

        public Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var add = (_registerRepository.Add(user));
            var userDTO = _mapper.Map<UserDTO>(add);

            return Task.FromResult(userDTO);
        }
    }
}
