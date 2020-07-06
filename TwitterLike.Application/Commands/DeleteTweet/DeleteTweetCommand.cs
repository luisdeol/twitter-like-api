using System;

namespace TwitterLike.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommand
    {
        public Guid TweetId { get; set; }
    }
}