using MediatR;

namespace TwitterLike.Application.Commands.SignUp
{
    public class SignUpCommand : IRequest<SignUpViewModel>
    {
        public SignUpCommand(SignUpInputModel signUpInputModel)
        {
            Name = signUpInputModel.Name;
            Username = signUpInputModel.Username;
            Email = signUpInputModel.Email;
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}