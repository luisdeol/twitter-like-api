using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterLike.Core.Entities;

namespace TwitterLike.Core.Repositories
{
    public interface IUserRepository
    {
         Task<List<Tweet>> GetTweetsByUserId(Guid userId);
         Task<Tweet> GetTweetById(Guid tweetId);
         Task<User> GetUserById(Guid userId);
         Task SaveAsync();
    }
}