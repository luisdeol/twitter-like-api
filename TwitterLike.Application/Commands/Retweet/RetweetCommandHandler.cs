using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.Retweet
{
    public class RetweetCommandHandler : IRequestHandler<RetweetCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public RetweetCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<Unit> Handle(RetweetCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.SaveRetweet(request.TweetId, request.UserId);
            
            return Unit.Value;
        }
    }
}