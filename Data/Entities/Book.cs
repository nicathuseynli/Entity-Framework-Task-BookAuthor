namespace EntityFramework_Task_BookAuthor.Data.Entities;
public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}
