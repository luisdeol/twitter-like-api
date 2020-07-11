using System;
using System.Collections.Generic;

namespace TwitterLike.Core.Entities
{
    public class Tweet
    {
        protected Tweet() { }
        public Tweet(string content, Guid userId)
        {
            Id = Guid.NewGuid();
            Content = !string.IsNullOrWhiteSpace(content) ? content : throw new ArgumentException("Content parameter is invalid.");
            UserId = userId;
            Active = true;
            CreatedAt = DateTime.Now;
            Likes = new List<TweetLike>();
            Retweets = new List<TweetRetweet>();
        }


        public Tweet(Guid id, string content, DateTime createdAt, bool active, Guid userId)
        {
            this.Id = id;
            this.Content = content;
            this.CreatedAt = createdAt;
            this.Active = active;
            this.UserId = userId;
        }

        public void SetAsDeleted() {
            Active = false;
            DeletedAt = DateTime.Now;
        }
        
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool Active { get; private set; }
        public List<TweetLike> Likes { get; private set; }
        public List<TweetRetweet> Retweets { get; private set; }
        public Guid UserId { get; set; }
        public User User { get; private set; }
    }
}