using System;

namespace TwitterLike.Core.Entities
{
    public class UserFollower
    {
        protected UserFollower() { }
        public UserFollower(Guid follower, Guid followee)
        {
            Follower = follower;
            Followee = followee;
        }

        public Guid Follower { get; private set; }
        public Guid Followee { get; private set; }
    }
}