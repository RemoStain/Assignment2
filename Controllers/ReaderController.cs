using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Data;
using System.Linq;

namespace Assignment2.Controllers
{
    public class ReaderController : Controller
    {
        private readonly LmsDbContext _context;

        public ReaderController(LmsDbContext context)
        {
            _context = context;
        }

        // Index action to show all readers
        public IActionResult Index(string searchString)
        {
            var readers = from r in _context.Readers
                          select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                readers = readers.Where(r => r.FirstName.Contains(searchString) || r.LastName.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(readers.ToList());
        }



        // Details action to show a specific reader
        public IActionResult Details(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // GET: Reader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reader/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return View(reader);
            }

            _context.Readers.Add(reader);
            return RedirectToAction("Index");
        }


        // Show form to edit existing reader
        public IActionResult Edit(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // Save changes to reader
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reader reader)
        {
            if (!ModelState.IsValid) return View(reader);
            _context.Readers.Update(reader);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Confirm delete
        public IActionResult Delete(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // Execute delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
