using System;

namespace TwitterLike.Core.Entities
{
    public class TweetRetweet
    {
        protected TweetRetweet() { }
        public TweetRetweet(Guid tweetId, Guid userId)
        {
            TweetId = tweetId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public Guid TweetId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}