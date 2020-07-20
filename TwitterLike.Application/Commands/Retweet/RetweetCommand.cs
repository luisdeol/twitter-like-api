using System;
using MediatR;

namespace TwitterLike.Application.Commands.Retweet
{
    public class RetweetCommand : IRequest<Unit>
    {
        public RetweetCommand(Guid tweetId, Guid userId)
        {
            TweetId = tweetId;
            UserId = userId;
        }

        public Guid TweetId { get; private set; }
        public Guid UserId { get; private set; }
    }
}