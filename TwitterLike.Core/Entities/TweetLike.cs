using System;

namespace TwitterLike.Core.Entities
{
    public class TweetLike
    {
        public Guid TweetId { get; set; }
        public Guid UserId { get; set; }
    }
}