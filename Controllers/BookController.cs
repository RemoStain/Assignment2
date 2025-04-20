using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Repositories;

namespace Assignment2.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repo;

        // Constructor
        public BookController(BookRepository repo)
        {
            _repo = repo;
        }

        // GET: /Book/
        public IActionResult Index()
        {
            var books = _repo.GetAll();
            return View(books);
        }

        // GET: /Book/Details/5
        public IActionResult Details(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: /Book/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: /Book/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _repo.GetById(id);
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
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
