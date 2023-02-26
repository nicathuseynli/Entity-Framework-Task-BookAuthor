using EntityFramework_Task_BookAuthor.Data.Context;
using EntityFramework_Task_BookAuthor.Data.Entities;
using EntityFramework_Task_BookAuthor.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Task_BookAuthor.Services.Implementation;
public class BookService : IBookService
{
    private readonly BookContext _context;

    public BookService(BookContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(string bookName, decimal price, string category)
    {
        Book book = new()
        {
            BookName = bookName,
            Price = price,
            Category = category
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Book> GetId(int id)
    {
        var result = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        return result;
    }

    public async Task<List<Book>> GetAll()
    {
        List<Book> books = await _context.Books.ToListAsync();
        if (books.Count == 0)
        {
            return null;
        }
        return books;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        if (result == null)
        {
            return false;
        }
        _context.Books.Remove(result);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Update(int id, decimal price, string bookName, string category)
    {
        Book book = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        if (book == null)
        {
            return false;
        }
        book.Price = price;
        book.Category = category;
        book.BookName = bookName;

        await _context.SaveChangesAsync();
        return true;
    }
}
