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

            //modelBuilder.Entity<ClientFavorite>().HasOne(c => c.Painting).WithMany(x => x.ClientFavorites).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Painting>().HasKey(p => p.PaintingID).IsClustered(false);
            modelBuilder.Entity<Painting>().HasIndex(i => new { i.PaintingName, i.CreationYear }).IsClustered(true);

            modelBuilder.Entity<Client>().HasKey(c => c.ClientID).IsClustered(false);
            modelBuilder.Entity<Client>().HasIndex(n => new { n.FirstName, n.LastName }).IsClustered(true);

            modelBuilder.Entity<ClientFavorite>().HasKey(c => c.ClientFavoriteID).IsClustered(false);
            modelBuilder.Entity<ClientFavorite>().HasIndex(d => d.DateCreated).IsClustered(true);

            modelBuilder.Entity<ClientCollection>().HasKey(c => c.ClientCollectionID).IsClustered(false);
            modelBuilder.Entity<ClientCollection>().HasIndex(n => n.Name).IsClustered(true);

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID).IsClustered(false);
            modelBuilder.Entity<Category>().HasIndex(n => n.Name).IsUnique(true).IsClustered(true);


            modelBuilder.Entity<PaintingCategory>()
                .HasKey(pc => new { pc.PaintingID, pc.CategoryID });
            modelBuilder.Entity<PaintingCategory>()
                .HasOne(p => p.Painting)
                .WithMany(pc => pc.PaintingCategories)
                .HasForeignKey(p => p.PaintingID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PaintingCategory>()
               .HasOne(c => c.Category)
               .WithMany(pc => pc.PaintingCategories)
               .HasForeignKey(c => c.CategoryID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientFavorite>()
                .HasKey(cf => new { cf.ClientID, cf.PaintingID });
            modelBuilder.Entity<ClientFavorite>()
                .HasOne(c => c.Client)
                .WithMany(cf => cf.ClientFavorites)
                .HasForeignKey(c => c.ClientID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClientFavorite>()
                .HasOne(p => p.Painting)
                .WithMany(cf => cf.ClientFavorites)
                .HasForeignKey(p => p.PaintingID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}