using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 3 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Non Fiction", DisplayOrder = 1 });

            // Seeding books data: 3 books per category
            modelBuilder.Entity<Book>().HasData(
                // Action
                new Book { ID = 1, Title = "Action Book 1", Description = "First action book", Author = "Author A1", Likes = 10, Price = 100.00, Review = "Sample Review 1", CategoryId = 1, ImageUrl = "" },
                new Book { ID = 2, Title = "Action Book 2", Description = "Second action book", Author = "Author A2", Likes = 15, Price = 120.00, Review = "Sample Review 2", CategoryId = 1, ImageUrl = "" },
                new Book { ID = 3, Title = "Action Book 3", Description = "Third action book", Author = "Author A3", Likes = 20, Price = 150.00, Review = "Sample Review 3", CategoryId = 1, ImageUrl = "" },

                // SciFi
                new Book { ID = 4, Title = "SciFi Book 1", Description = "First scifi book", Author = "Author S1", Likes = 12, Price = 230.00, Review = "Sample review 1", CategoryId = 2, ImageUrl = "" },
                new Book { ID = 5, Title = "SciFi Book 2", Description = "Second scifi book", Author = "Author S2", Likes = 18, Price = 230.00, Review = "Sample review 3", CategoryId = 2, ImageUrl = "" },
                new Book { ID = 6, Title = "SciFi Book 3", Description = "Third scifi book", Author = "Author S3", Likes = 22, Price = 230.00, Review = "Sample review 4", CategoryId = 2, ImageUrl = "" },

                // Non Fiction
                new Book { ID = 7, Title = "Non Fiction Book 1", Description = "First non fiction book", Author = "Author N1", Likes = 8, Price = 450.50, Review = "Sample review book 1", CategoryId = 3, ImageUrl = "" },
                new Book { ID = 8, Title = "Non Fiction Book 2", Description = "Second non fiction book", Author = "Author N2", Likes = 14, Price = 600.00, Review = "Sample review book 2", CategoryId = 3, ImageUrl = "" },
                new Book { ID = 9, Title = "Non Fiction Book 3", Description = "Third non fiction book", Author = "Author N3", Likes = 19, Price = 580.00, Review = "Sample review book 3", CategoryId = 3, ImageUrl = "" }
            );
        }
    }
}
