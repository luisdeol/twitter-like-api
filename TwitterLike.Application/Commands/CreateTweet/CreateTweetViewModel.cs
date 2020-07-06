using System;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetViewModel
    {
        public CreateTweetViewModel(Guid id, string description, Guid userId)
        {
            Id = id;
            Description = description;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid UserId { get; private set; }
    }
}