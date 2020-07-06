using System;

namespace TwitterLike.Application.Queries.GetTweet
{
    public class GetTweetUserViewModel
    {
        public GetTweetUserViewModel(Guid userId, string username, string name)
        {
            UserId = userId;
            Username = username;
            Name = name;
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Name { get; private set; }
    }
}