using System;

namespace TwitterLike.Core.Entities
{
    public class TweetRetweet
    {
        public Guid TweetId { get; set; }
        public Guid UserId { get; set; }
    }
}