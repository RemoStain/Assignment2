using Assignment2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Repositories
{
    public class BookRepository
    {
        private List<Book> _books;

        public BookRepository()
        {
            // Initialize with some dummy data (this can be replaced with real DB context)
            _books = new List<Book>
            {
                //new Book { BookId = 1, Title = "Book 1", Author = "Author 1", PublishedYear = new DateTime(2020, 1, 1) },
                //new Book { BookId = 2, Title = "Book 2", Author = "Author 2", PublishedYear = new DateTime(2021, 1, 1) }
            };
        }

        // Get all books
        public List<Book> GetAll()
        {
            return _books;
        }

        // Get a book by Id
        public Book GetById(int id)
        {
            return _books.FirstOrDefault(b => b.BookId == id);
        }

        // Add a new book
        public void Add(Book book)
        {
            _books.Add(book);
        }

        // Update a book
        public void Update(Book book)
        {
            var existingBook = GetById(book.BookId);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublishedYear = book.PublishedYear;
            }
        }

        // Delete a book
        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
