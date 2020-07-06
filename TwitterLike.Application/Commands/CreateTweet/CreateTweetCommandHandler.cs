using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Application.Exceptions;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetCommandHandler : IRequestHandler<CreateTweetCommand, CreateTweetViewModel>
    {
        private readonly IUserRepository _userRepository;
        public CreateTweetCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<CreateTweetViewModel> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            if (user == null) {
                throw new NotFoundException(nameof(User));
            }
            
            var newTweet = user.AddTweet(request.Content);

            await _userRepository.SaveAsync();
            
            return new CreateTweetViewModel(newTweet.Id, newTweet.Content, newTweet.UserId); 
        }
    }
}