using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly BorrowingRepository _repo = new BorrowingRepository();
        private readonly BookRepository _bookRepo = new BookRepository();
        private readonly ReaderRepository _readerRepo = new ReaderRepository();

        // Index action to show all borrowings
        public IActionResult Index()
        {
            var borrowings = _repo.GetAll();
            return View(borrowings);
        }

        // Details action to show a specific borrowing
        public IActionResult Details(int id)
        {
            var borrowing = _repo.GetById(id);
            if (borrowing == null) return NotFound();
            return View(borrowing);
        }

        // Create action for adding a new borrowing
        public IActionResult Create()
        {
            // Use SelectList to bind BookId and ReaderId in the form
            ViewBag.Books = new SelectList(_bookRepo.GetAll(), "BookId", "Title");
            ViewBag.Readers = new SelectList(_readerRepo.GetAll(), "ReaderId", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrowing borrowing)
        {
            if (!ModelState.IsValid) return View(borrowing);
            _repo.Add(borrowing);
            return RedirectToAction("Index");
        }

        // Edit action to update borrowing details
        public IActionResult Edit(int id)
        {
            var borrowing = _repo.GetById(id);
            if (borrowing == null) return NotFound();
            return View(borrowing);
        }

        [HttpPost]
        public IActionResult Edit(Borrowing borrowing)
        {
            if (!ModelState.IsValid) return View(borrowing);
            _repo.Update(borrowing);
            return RedirectToAction("Index");
        }

        // Delete action for deleting a borrowing
        public IActionResult Delete(int id)
        {
            var borrowing = _repo.GetById(id);
            if (borrowing == null) return NotFound();
            return View(borrowing);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
