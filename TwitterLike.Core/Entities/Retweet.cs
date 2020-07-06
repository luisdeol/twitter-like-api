using System;

namespace TwitterLike.Core.Entities
{
    public class TweetRetweet
    {
        protected TweetRetweet() {}
        public Guid TweetId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}