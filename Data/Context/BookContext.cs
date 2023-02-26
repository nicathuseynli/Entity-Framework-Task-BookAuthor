using EntityFramework_Task_BookAuthor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Task_BookAuthor.Data.Context;
public class BookContext:DbContext
{
    public BookContext(DbContextOptions options): base(options)
    {

    }
    public DbSet<Book>Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(b =>
        {
            b.ToTable("tbl_Book");
            b.HasKey("Id");
        });
    }
}
