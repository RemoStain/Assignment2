using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReaderController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllReaders()
    {
        return Ok("List of all readers.");
    }

    [HttpGet("{id}")]
    public IActionResult GetReaderById(int id)
    {
        return Ok($"Details of reader with ID {id}.");
    }

    [HttpPost]
    public IActionResult AddReader()
    {
        return Ok("Reader added successfully.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReader(int id)
    {
        return Ok($"Reader with ID {id} updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReader(int id)
    {
        return Ok($"Reader with ID {id} deleted.");
    }
}
