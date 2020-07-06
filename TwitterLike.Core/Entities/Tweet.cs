using System;
using System.Collections.Generic;

namespace TwitterLike.Core.Entities
{
    public class Tweet
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public List<TweetLike> Likes { get; set; }
        public List<TweetRetweet> Retweets { get; set; }
    }
}