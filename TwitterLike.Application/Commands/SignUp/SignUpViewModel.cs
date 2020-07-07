using System;

namespace TwitterLike.Application.Commands.SignUp
{
    public class SignUpViewModel
    {
        public SignUpViewModel(Guid userId, string name, string username)
        {
            UserId = userId;
            Name = name;
            Username = username;
        }

        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
    }
}