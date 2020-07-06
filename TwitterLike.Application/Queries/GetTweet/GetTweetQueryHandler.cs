using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Queries.GetTweet
{
    public class GetTweetQueryHandler : IRequestHandler<GetTweetQuery, GetTweetViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetTweetQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetTweetViewModel> Handle(GetTweetQuery request, CancellationToken cancellationToken)
        {
            var tweet = await _userRepository.GetTweetById(request.TweetId);

            if (tweet == null) {
                return null;
            }

            return new GetTweetViewModel(tweet.Id, tweet.Content, new GetTweetUserViewModel(tweet.UserId, "teste", "teste"));
        }
    }
}