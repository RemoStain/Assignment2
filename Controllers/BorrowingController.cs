using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2.Data; 

namespace Assignment2.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly LmsDbContext _context;

        // Inject LmsDbContext into the controller
        public BorrowingController(LmsDbContext context)
        {
            _context = context;
        }

        // Index action to show all borrowings
        public IActionResult Index()
        {
            // Get all borrowings from the database
            var borrowings = _context.Borrowings.ToList(); // Fetch from DB using DbContext
            return View(borrowings);
        }

        // Details action to show a specific borrowing
        public IActionResult Details(int id)
        {
            var borrowing = _context.Borrowings
                .FirstOrDefault(b => b.BookId == id); // Fetch a specific borrowing by ID

            if (borrowing == null)
                return NotFound();

            return View(borrowing);
        }

        // Create action for adding a new borrowing
        public IActionResult Create()
        {
            // Use SelectList to bind BookId and ReaderId in the form
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title");
            ViewBag.Readers = new SelectList(_context.Readers, "ReaderId", "FirstName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrowing borrowing)
        {
            if (!ModelState.IsValid)
                return View(borrowing);

            // Add borrowing to the DB
            _context.Borrowings.Add(borrowing);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Edit action to update borrowing details
        public IActionResult Edit(int id)
        {
            var borrowing = _context.Borrowings
                .FirstOrDefault(b => b.BookId == id);

            if (borrowing == null)
                return NotFound();

            return View(borrowing);
        }

        [HttpPost]
        public IActionResult Edit(Borrowing borrowing)
        {
            if (!ModelState.IsValid)
                return View(borrowing);

            _context.Borrowings.Update(borrowing);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Delete action for deleting a borrowing
        public IActionResult Delete(int id)
        {
            var borrowing = _context.Borrowings
                .FirstOrDefault(b => b.BookId == id);

            if (borrowing == null)
                return NotFound();

            return View(borrowing);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var borrowing = _context.Borrowings
                .FirstOrDefault(b => b.BookId == id);

            if (borrowing != null)
            {
                _context.Borrowings.Remove(borrowing);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
