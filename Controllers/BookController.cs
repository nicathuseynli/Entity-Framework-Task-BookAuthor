using EntityFramework_Task_BookAuthor.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework_Task_BookAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, decimal price, string category)
        {
            await _bookService.Create(name, price, category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, decimal price, string bookName, string category)
        {
            var result = await _bookService.Update(id, price, bookName, category);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _bookService.Delete(id);
            if (result == false)
                return NotFound();

            return Ok(result);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _bookService.GetId(id);
            return Ok(result);
        }
    }
}