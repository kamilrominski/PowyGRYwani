using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PowygrywaniApi.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
            
        }
        public DbSet<Game> games { get; set; } = null;
        public DbSet<Comment> comment { get; set; } = null;
        public DbSet<Language> languages { get; set; } = null;
        public DbSet<Platform> platforms { get; set; } = null;
        public DbSet<Rating> ratings { get; set; } = null;
        public DbSet<Series> series { get; set; } = null;
        public DbSet<Studio> studios { get; set; } = null;
        public DbSet<Tag> tags { get; set; } = null;
        public DbSet<User> users { get; set; } = null;
    }
}
