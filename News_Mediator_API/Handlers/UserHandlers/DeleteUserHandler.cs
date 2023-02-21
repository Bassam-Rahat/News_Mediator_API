using MediatR;
using News_Mediator_API.Commands;
using News_Mediator_API.Commands.UserCommands;
using News_Mediator_API.Repository.Interfaces;

namespace News_Mediator_API.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IRegisterRepository _registerRepository;
        public DeleteUserHandler(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_registerRepository.Delete(request.id));
        }
    }
}
