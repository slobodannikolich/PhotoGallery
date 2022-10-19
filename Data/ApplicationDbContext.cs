using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Models;

namespace PhotoGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientFavorite> ClientFavorites { get; set; }
        public DbSet<ClientCollection> ClientCollections { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<PaintingCategory> PaintingCategorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasKey(c => c.AuthorID).IsClustered(false);
            modelBuilder.Entity<Author>().HasIndex(c => new { c.FirstName, c.LastName }).IsUnique(true).IsClustered(true);
        }
    }
}