using System;
using MediatR;

namespace TwitterLike.Application.Commands.LikeTweet
{
    public class LikeTweetCommand : IRequest<Unit>
    {
        public LikeTweetCommand(Guid likeGiverId, Guid tweetId)
        {
            UserId = likeGiverId;
            TweetId = tweetId;
        }

        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
    }
}