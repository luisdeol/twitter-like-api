using System;
using MediatR;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<CreateTweetViewModel>
    {
        public CreateTweetCommand(string description, Guid userId)
        {
            Description = description;
            UserId = userId;
        }

        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}