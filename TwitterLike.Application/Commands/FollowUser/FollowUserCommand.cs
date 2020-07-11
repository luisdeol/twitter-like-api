using System;
using MediatR;

namespace TwitterLike.Application.Commands.FollowUser
{
    public class FollowUserCommand : IRequest<Unit>
    {
        public FollowUserCommand(Guid followerId, Guid followeeId)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }

        public Guid FollowerId { get; private set; }
        public Guid FolloweeId { get; private set; }
    }
}