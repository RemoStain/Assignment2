using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllBorrowings()
    {
        return Ok("List of all borrowings.");
    }

    [HttpGet("{id}")]
    public IActionResult GetBorrowingById(int id)
    {
        return Ok($"Details of borrowing with ID {id}.");
    }

    [HttpPost]
    public IActionResult AddBorrowing()
    {
        return Ok("Borrowing record added successfully.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBorrowing(int id)
    {
        return Ok($"Borrowing record with ID {id} updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBorrowing(int id)
    {
        return Ok($"Borrowing record with ID {id} deleted.");
    }
}
