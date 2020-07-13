using System;

namespace TwitterLike.Core.Entities
{
    public class TweetLike
    {
        public TweetLike(Guid tweetId, Guid userId)
        {
            TweetId = tweetId;
            UserId = userId;
        }

        public Guid TweetId { get; private set; }
        public Guid UserId { get; private set; }
    }
}