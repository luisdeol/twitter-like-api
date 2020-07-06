using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TwitterLike.Application.Queries.GetTweet
{
    public class GetTweetQueryHandler : IRequestHandler<GetTweetQuery, GetTweetViewModel>
    {
        public Task<GetTweetViewModel> Handle(GetTweetQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetTweetViewModel(request.TweetId, "Testing...", new GetTweetUserViewModel(request.UserId, "user_test", "User Test")));
        }
    }
}