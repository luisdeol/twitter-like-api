using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TwitterLike.Application.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpViewModel>
    {
        public Task<SignUpViewModel> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SignUpViewModel(Guid.NewGuid(), "test name", "test"));
        }
    }
}