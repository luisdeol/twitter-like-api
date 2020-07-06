using System;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetViewModel
    {
        public CreateTweetViewModel(Guid id, string content, Guid userId)
        {
            Id = id;
            Content = content;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public Guid UserId { get; private set; }
    }
}