using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleStupid.Model;

namespace SimpleStupid.Data
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Category> Catagories {get;set;}
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Image"},
                new Category {Id = 2, Name = "Link"},
                new Category {Id = 3, Name = "Directory"},
                new Category {Id = 4, Name = "Text"}
            );
        }
    }
}
