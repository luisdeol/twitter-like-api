using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.LikeTweet
{
    public class LikeTweetCommandHandler : IRequestHandler<LikeTweetCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public LikeTweetCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(LikeTweetCommand request, CancellationToken cancellationToken)
        {
            var tweetLike = new TweetLike(request.TweetId, request.UserId);

            await _userRepository.SaveTweetLike(tweetLike);

            return Unit.Value;
        }
    }
}