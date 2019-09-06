using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Pisstaube.CacheDb.Models;

namespace Pisstaube.CacheDb
{
    public class PisstaubeCacheDbContext : DbContext
    {
        private readonly string _conString;
        public DbSet<CacheBeatmapSet> CacheBeatmapSet { get; [UsedImplicitly] set; }
        public DbSet<Beatmap> CacheBeatmaps { get; [UsedImplicitly] set; }
        
        public PisstaubeCacheDbContext(string conString = null)
        {
            _conString = conString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlite(_conString);
        }
        
        public void Migrate() => Database.Migrate();
    }
}