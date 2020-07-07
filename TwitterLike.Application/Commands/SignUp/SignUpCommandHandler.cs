using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpViewModel>
    {
        private readonly IUserRepository _userRepository;
        public SignUpCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<SignUpViewModel> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Username, request.Email);

            await _userRepository.Add(user);
            await _userRepository.SaveAsync();

            var signUpViewModel = new SignUpViewModel(user.Id, user.Name, user.Username);

            return signUpViewModel;
        }
    }
}