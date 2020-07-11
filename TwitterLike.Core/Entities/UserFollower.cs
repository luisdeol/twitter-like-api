using System;

namespace TwitterLike.Core.Entities
{
    public class UserFollower
    {
        protected UserFollower() { }
        public UserFollower(Guid follower, Guid followee)
        {
            FollowerId = follower;
            FolloweeId = followee;
        }

        public Guid FollowerId { get; private set; }
        public Guid FolloweeId { get; private set; }
    }
}