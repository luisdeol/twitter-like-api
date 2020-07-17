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
            
            var followeesCount = await _twitterLikeDbContext.Followers.CountAsync(f => f.FollowerId == userId);
            
            user.SetFollowersCount(followeesCount);
            
            return user;
        }

        public async Task SaveAsync()
        {
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task<Tweet> GetTweetById(Guid tweetId)
        {
            var tweet = await _twitterLikeDbContext
                .Tweets
                .AsNoTracking()
                .Include(t => t.User)
                .SingleOrDefaultAsync(t => t.Id == tweetId && t.Active);
            
            var likesAmount = await _twitterLikeDbContext
                .TweetLikes
                .CountAsync(t => t.TweetId == tweetId);

            tweet.SetLikesAmount(likesAmount);

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

        public async Task DeleteTweet(Guid userId, Guid tweetId)
        {
            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userId && u.Active)) {
                throw new NotFoundException(nameof(User));
            }

            var tweet = await _twitterLikeDbContext.Tweets.SingleOrDefaultAsync(t => t.Id == tweetId && t.UserId == userId);

            if (tweet == null) {
                throw new NotFoundException(nameof(Tweet));
            }

            tweet.SetAsDeleted();
            
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task AddFollowee(Guid followerId, Guid followeeId)
        {
            var userFollower = new UserFollower(followerId, followeeId);
            
            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userFollower.FolloweeId) && !await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == userFollower.FollowerId)){
                throw new NotFoundException(nameof(Tweet));
            }

            _twitterLikeDbContext.Entry(userFollower).State = EntityState.Added;
            await _twitterLikeDbContext.SaveChangesAsync();
        }

        public async Task SaveTweetLike(Guid tweetId, Guid userId)
        {
            var tweetLike = new TweetLike(tweetId, userId);
            
            if (!await _twitterLikeDbContext.Tweets.AnyAsync(t => t.Id == tweetLike.TweetId)) {
                throw new NotFoundException(nameof(Tweet));
            }

            if (!await _twitterLikeDbContext.Users.AnyAsync(u => u.Id == tweetLike.UserId)) {
                throw new NotFoundException(nameof(User));
            }

            _twitterLikeDbContext.Entry(tweetLike).State = EntityState.Added;
            await _twitterLikeDbContext.SaveChangesAsync();
        }
    }
}