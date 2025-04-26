using Microsoft.EntityFrameworkCore;
using WatchesTok.Models;

namespace WatchesTok.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> ElePost { get; set; }
        public DbSet<Utente> EleUtenti { get; set; }
        public DbSet<Like> EleLikes { get; set; }

        public DbSet<Commenti> EleCommenti { get; set; }
        public DbSet<Orologio> EleOrologi { get; set; }

    }
}
