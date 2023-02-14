using MediatR;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Interfaces;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IRegisterRepository _registerRepository;
        public AddUserHandler(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_registerRepository.Add(request.user));
        }
    }
}
