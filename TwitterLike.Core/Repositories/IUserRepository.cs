using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterLike.Core.Entities;

namespace TwitterLike.Core.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task AddTweet(Guid userId, Tweet tweet);
        Task DeleteTweet(Guid userId, Guid tweetId);
        Task SaveTweetLike(Guid tweetId, Guid userId);
        Task AddFollowee(Guid followerId, Guid followeeId);
        
        Task<List<Tweet>> GetTweetsByUserId(Guid userId);
        Task<Tweet> GetTweetById(Guid tweetId);
        Task<User> GetUserById(Guid userId);

        Task SaveAsync();
    }
}