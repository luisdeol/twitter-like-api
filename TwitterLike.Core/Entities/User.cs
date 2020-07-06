using System;
using System.Collections.Generic;
using TwitterLike.Core.Exceptions;

namespace TwitterLike.Core.Entities
{
    public class User
    {
        protected User() { }
        public User(string username, List<Tweet> tweets) {
            Id = Guid.NewGuid();
            Username = username;
            CreatedAt = DateTime.Now;
            Active = true;
            Tweets = tweets ?? new List<Tweet>();
            Followers = new List<UserFollower>();
        }
        

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Username { get; private set; }
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

        public Tweet AddTweet(string description) {
            if (string.IsNullOrWhiteSpace(description)) {
                throw new ArgumentNullException("The Tweet input data is invalid.");
            }

            if (Tweets != null) {
                var newTweet = new Tweet(description);

                Tweets.Add(newTweet);

                return newTweet;
            } else {
                throw new InvalidStateException(nameof(User));
            }
        }
    }
}