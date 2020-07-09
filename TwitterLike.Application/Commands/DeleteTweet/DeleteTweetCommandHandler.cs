using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommandHandler : IRequestHandler<DeleteTweetCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteTweetCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;    
        }

        public async Task<Unit> Handle(DeleteTweetCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteTweet(request.UserId, request.TweetId);

            return Unit.Value;
        }
    }
}