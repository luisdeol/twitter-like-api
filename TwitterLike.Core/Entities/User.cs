using System;
using System.Collections.Generic;
using TwitterLike.Core.Exceptions;

namespace TwitterLike.Core.Entities
{
    public class User
    {
        protected User() { }
        public User(string name, string username, string email) {
            Id = Guid.NewGuid();
            Name = name;
            Username = username;
            Email = email;
            CreatedAt = DateTime.Now;
            Active = true;
            Tweets = new List<Tweet>();
            Followers = new List<UserFollower>();
        }
        

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Username { get; private set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public List<Tweet> Tweets { get; private set; }
        public List<UserFollower> Followers { get; private set; }

        public void Follow(Guid follower) {
            if (Followers != null) {
                var userFollower = new UserFollower(follower, Id);

                Followers.Add(userFollower);
            } else {
                throw new InvalidStateException(nameof(User));
            }
        }
    }
}