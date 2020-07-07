using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TwitterLikeDbContext _twitterLikeDbContext;
        public UserRepository(TwitterLikeDbContext twitterLikeDbContext)
        {
            _twitterLikeDbContext = twitterLikeDbContext;
        }
        
        public async Task AddUser(User user) {
            await _twitterLikeDbContext.Users.AddAsync(user);
        }
        
        public async Task<List<Tweet>> GetTweetsByUserId(Guid userId)
        {
            return await _twitterLikeDbContext.Tweets.ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            User user;
            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userId)) {
                user = new User("test", "test", "test@email.com", new List<Tweet>());

                await AddUser(user);
                await SaveAsync();
            } else {
                user =  await _twitterLikeDbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            }

            return user;
        }

        public async Task SaveAsync()
        {
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task<Tweet> GetTweetById(Guid tweetId)
        {
            return await _twitterLikeDbContext.Tweets.SingleOrDefaultAsync(t => t.Id == tweetId && t.Active);
        }
    }
}