using System;
using MediatR;

namespace TwitterLike.Application.Queries.GetTweet
{
    public class GetTweetQuery : IRequest<GetTweetViewModel>
    {
        public GetTweetQuery(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
        }

        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
    }
}