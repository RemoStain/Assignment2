using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Repositories;

namespace Assignment2.Controllers
{
    public class ReaderController : Controller
    {
        private readonly ReaderRepository _repo = new ReaderRepository();

        // Index action to show all readers
        public IActionResult Index()
        {
            var readers = _repo.GetAll();
            return View(readers);
        }

        // Details action to show a specific reader
        public IActionResult Details(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // Create action to show the form for creating a new reader
        public IActionResult Create()
        {
            return View();
        }

        // Create action to save the new reader to the database
        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid) return View(reader);
            _repo.Add(reader);
            return RedirectToAction("Index");
        }

        // Edit action to show the form for editing a reader
        public IActionResult Edit(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // Edit action to update the reader's data
        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            if (!ModelState.IsValid) return View(reader);
            _repo.Update(reader);
            return RedirectToAction("Index");
        }

        // Delete action to show confirmation for deleting a reader
        public IActionResult Delete(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        // DeleteConfirmed action to delete the reader
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
