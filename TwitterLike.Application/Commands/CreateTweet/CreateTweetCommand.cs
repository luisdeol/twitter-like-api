using System;
using MediatR;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<CreateTweetViewModel>
    {
        public CreateTweetCommand(string content, Guid userId)
        {
            Content = content;
            UserId = userId;
        }

        public string Content { get; private set; }
        public Guid UserId { get; private set; }
    }
}