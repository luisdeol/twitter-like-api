using System;
using MediatR;

namespace TwitterLike.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommand : IRequest<Unit>
    {
        public DeleteTweetCommand(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
        }

        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
    }
}