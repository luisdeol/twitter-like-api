using Microsoft.EntityFrameworkCore;
using TwitterLike.Core.Entities;

namespace TwitterLike.Infrastructure.Persistence
{
    public class TwitterLikeDbContext : DbContext
    {
        public TwitterLikeDbContext(DbContextOptions<TwitterLikeDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFollower> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Tweet>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Tweet>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tweets)
                .HasForeignKey(t => t.UserId);

            modelBuilder
                .Entity<Tweet>()
                .HasMany(t => t.Retweets)
                .WithOne()
                .HasForeignKey(r => r.UserId);

            modelBuilder
                .Entity<Tweet>()
                .HasMany(t => t.Likes)
                .WithOne()
                .HasForeignKey(l => l.UserId);

            modelBuilder
                .Entity<TweetLike>()
                .HasKey(tl => new { tl.UserId, tl.TweetId });

            modelBuilder
                .Entity<TweetRetweet>()
                .HasKey(tr => new { tr.TweetId, tr.UserId});
            
            modelBuilder
                .Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<User>()
                .Ignore(u => u.FolloweesCount);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Tweets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder
                .Entity<UserFollower>()
                .HasKey(uf => new { uf.FolloweeId, uf.FollowerId });
        }
    }
}