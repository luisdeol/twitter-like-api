using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Exceptions;
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
                throw new NotFoundException(nameof(Tweet));
            }

            return new GetTweetViewModel(tweet.Id, tweet.Content, new GetTweetUserViewModel(tweet.UserId, tweet.User.Username, tweet.User.Name), tweet.LikesAmount);
        }
    }
}