using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Data;
using System.Linq;

namespace Assignment2.Controllers
{
    public class BookController : Controller
    {
        private readonly LmsDbContext _context;

        public BookController(LmsDbContext context)
        {
            _context = context;
        }

        // GET: /Book/
        public IActionResult Index(string searchString)
        {
            var book = from r in _context.Books
                          select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                book = book.Where(r => r.Title.Contains(searchString) || r.Author.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(book.ToList());
        }


        // GET: /Book/Details/5
        public IActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        // GET: /Book/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges(); // Save updates
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: /Book/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges(); // Save deletion
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
