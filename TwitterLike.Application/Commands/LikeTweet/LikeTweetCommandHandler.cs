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
            await _userRepository.SaveTweetLike(request.TweetId, request.UserId);

            return Unit.Value;
        }
    }
}