using System;
using MediatR;

namespace TwitterLike.Application.Commands.LikeTweet
{
    public class LikeTweetCommand : IRequest<Unit>
    {
        public LikeTweetCommand(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
        }

        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
    }
}