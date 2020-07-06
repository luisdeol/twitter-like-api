using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TwitterLike.Application.Commands.CreateTweet
{
    public class CreateTweetCommandHandler : IRequestHandler<CreateTweetCommand, CreateTweetViewModel>
    {
        public Task<CreateTweetViewModel> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateTweetViewModel(Guid.NewGuid(), request.Description, request.UserId)); 
        }
    }
}