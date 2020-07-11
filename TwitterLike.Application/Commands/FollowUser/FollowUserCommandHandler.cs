using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public FollowUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var userFollower = new UserFollower(request.FollowerId, request.FolloweeId);

            await _userRepository.AddFollowee(userFollower);

            return Unit.Value;
        }
    }
}