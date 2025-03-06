using LuxStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using System.Reflection;

namespace LuxStore.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here. Configuration ayarlarını buraya ekleyeceğiz.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //seed data
            DataSeed.SeedData.AppUserSeedData(modelBuilder);
            DataSeed.SeedData.CategorySeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}