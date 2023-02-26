using EntityFramework_Task_BookAuthor.Data.Entities;

namespace EntityFramework_Task_BookAuthor.Services.Interface;
public interface IBookService
{
    Task<List<Book>> GetAll();
    Task<Book> GetId(int id);
    Task<bool> Create(string bookName, decimal price, string category);
    Task<bool> Update(int id, decimal price, string bookName, string category);
    Task<bool> Delete(int id);
}
