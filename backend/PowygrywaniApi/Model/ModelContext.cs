using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PowygrywaniApi.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options){}
        public DbSet<Game> games { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Platform> platforms { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Series> series { get; set; }
        public DbSet<Studio> studios { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<User> users { get; set; }
    }
}
