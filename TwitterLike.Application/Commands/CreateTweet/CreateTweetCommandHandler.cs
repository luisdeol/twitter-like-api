using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            var tweet = new Tweet(request.Content, request.UserId);

            await _userRepository.AddTweet(request.UserId, tweet);
            
            return new CreateTweetViewModel(tweet.Id, tweet.Content, tweet.UserId); 
        }
    }
}