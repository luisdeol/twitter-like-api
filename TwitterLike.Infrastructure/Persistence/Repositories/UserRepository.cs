using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Exceptions;
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
        
        public async Task<List<Tweet>> GetTweetsByUserId(Guid userId)
        {
            return await _twitterLikeDbContext.Tweets.ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userId && u.Active)) {
                throw new NotFoundException(nameof(User));
            }

            var user = await _twitterLikeDbContext.Users.SingleOrDefaultAsync(u => u.Id == userId && u.Active);

            return user;
        }

        public async Task SaveAsync()
        {
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task<Tweet> GetTweetById(Guid tweetId)
        {
            var tweet = await _twitterLikeDbContext.Tweets.SingleOrDefaultAsync(t => t.Id == tweetId && t.Active);

            return tweet;
        }

        public async Task Add(User user)
        {
            await _twitterLikeDbContext.Users.AddAsync(user);
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task AddTweet(Guid userId, Tweet tweet)
        {
            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userId && u.Active)) {
                throw new NotFoundException(nameof(User));
            }

            await _twitterLikeDbContext.Tweets.AddAsync(tweet);
            await _twitterLikeDbContext.SaveChangesAsync();
        }
    }
}