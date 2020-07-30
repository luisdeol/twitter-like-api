using System;
using System.Collections.Generic;

namespace TwitterLike.Application.Queries.GetUserTimeline
{
    public class GetUserTimelineViewModel
    {
        public GetUserTimelineViewModel(string fullName, List<GetUserTimelineTweetItem> tweets)
        {
            FullName = fullName;
            Tweets = tweets;
        }

        public string FullName { get; private set; }
        public List<GetUserTimelineTweetItem> Tweets { get; private set; }
    }

    public class GetUserTimelineTweetItem
    {
        public GetUserTimelineTweetItem(Guid tweetId, string username, string userFullName, DateTime createdAt)
        {
            TweetId = tweetId;
            Username = username;
            UserFullName = userFullName;
            CreatedAt = createdAt;
        }

        public Guid TweetId { get; private set; }
        public string Username { get; private set; }
        public string UserFullName { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}