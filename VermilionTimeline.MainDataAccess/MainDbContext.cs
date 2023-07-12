using Microsoft.EntityFrameworkCore;
using VermilionTimeline.MainDataAccess.Entities;

namespace VermilionTimeline.MainDataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<AccountClaim> AccountClaim { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Clue> Clue { get; set; }
        public DbSet<Gain> Gain { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}