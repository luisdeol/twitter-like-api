using System;
using MediatR;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<CreateTweetViewModel>
    {
        public CreateTweetCommand(CreateTweetInputModel createTweetInputModel, Guid userId)
        {
            Content = createTweetInputModel.Content;
            UserId = userId;
        }

        public string Content { get; private set; }
        public Guid UserId { get; private set; }
    }
}