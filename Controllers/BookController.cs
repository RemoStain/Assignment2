using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok("List of all books.");
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        return Ok($"Details of book with ID {id}.");
    }

    [HttpPost]
    public IActionResult AddBook()
    {
        return Ok("Book added successfully.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id)
    {
        return Ok($"Book with ID {id} updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        return Ok($"Book with ID {id} deleted.");
    }
}
