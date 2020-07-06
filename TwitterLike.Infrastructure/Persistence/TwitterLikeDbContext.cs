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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Tweet>()
                .HasKey(t => t.Id);
            
            modelBuilder
                .Entity<Tweet>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();


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
                .HasMany(u => u.Tweets)
                .WithOne()
                .HasForeignKey(t => t.UserId);

            modelBuilder
                .Entity<UserFollower>()
                .HasKey(uf => new { uf.Followee, uf.Follower });
        }
    }
}