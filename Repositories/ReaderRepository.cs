using Assignment2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Repositories
{
    public class ReaderRepository
    {
        private static List<Reader> _readers = new List<Reader>();
        private static int _nextId = 1;

        public List<Reader> GetAll()
        {
            return _readers;
        }

        public Reader? GetById(int id)
        {
            return _readers.FirstOrDefault(r => r.ReaderId == id);
        }

        public void Add(Reader reader)
        {
            reader.ReaderId = _nextId++;
            _readers.Add(reader);
        }

        public void Update(Reader reader)
        {
            var existing = GetById(reader.ReaderId);
            if (existing != null)
            {
                existing.FirstName = reader.FirstName;
                existing.LastName = reader.LastName;
                existing.Email = reader.Email;
                existing.PhoneNumber = reader.PhoneNumber;
                existing.Address = reader.Address;
            }
        }

        public void Delete(int id)
        {
            var reader = GetById(id);
            if (reader != null)
            {
                _readers.Remove(reader);
            }
        }
    }
}
