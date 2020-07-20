using System;

namespace TwitterLike.Application.Queries.GetTweet
{
    public class GetTweetViewModel
    {
        public GetTweetViewModel(Guid tweetId, string description, GetTweetUserViewModel user, int likesAmount, int retweetsAmount)
        {
            TweetId = tweetId;
            Description = description;
            User = user;
            LikesAmount = likesAmount;
            RetweetsAmount = retweetsAmount;
        }

        public Guid TweetId { get; private set; }
        public string Description { get; private set; }
        public GetTweetUserViewModel User { get; private set; }
        public int LikesAmount { get; private set; }
        public int RetweetsAmount { get; private set; }
    }
}