using Assignment2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Repositories
{
    public class BorrowingRepository
    {
        private static List<Borrowing> _borrowings = new List<Borrowing>();
        private static int _nextId = 1;

        public List<Borrowing> GetAll()
        {
            return _borrowings;
        }

        public Borrowing? GetById(int id)
        {
            return _borrowings.FirstOrDefault(b => b.BorrowingId == id);
        }

        public void Add(Borrowing borrowing)
        {
            borrowing.BorrowingId = _nextId++;
            _borrowings.Add(borrowing);
        }

        public void Update(Borrowing borrowing)
        {
            var existing = GetById(borrowing.BorrowingId);
            if (existing != null)
            {
                existing.BookId = borrowing.BookId;
                existing.ReaderId = borrowing.ReaderId;
                existing.BorrowDate = borrowing.BorrowDate;
                existing.DueDate = borrowing.DueDate;
                existing.ReturnDate = borrowing.ReturnDate;
            }
        }

        public void Delete(int id)
        {
            var borrowing = GetById(id);
            if (borrowing != null)
            {
                _borrowings.Remove(borrowing);
            }
        }
    }
}
