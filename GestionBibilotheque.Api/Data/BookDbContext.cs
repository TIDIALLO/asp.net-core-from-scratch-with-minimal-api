
using GestionBibilotheque.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionBibilotheque.Api.Data;

public class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
{
    public DbSet<Book>? Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                DatePub = new DateOnly(2008, 8, 1)
            },
            new Book
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                DatePub = new DateOnly(1999, 10, 20)
            },
            new Book
            {
                Id = 3,
                Title = "Design Patterns",
                Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                DatePub = new DateOnly(1994, 10, 31)
            }
        );
    }

}
