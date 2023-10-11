using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAssignment
{
    public class BookRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter", Price = 199.99 },
            new Book { Id = 2, Title = "Lord of the Rings", Price = 169.99 },
            new Book { Id = 3, Title = "Jurassic Park", Price = 129.99 },
            new Book { Id = 4, Title = "Twilight", Price = 89.99 },
            new Book { Id = 5, Title = "The Godfather", Price = 89.99 }
        };

        public IEnumerable<Book> Get(string? title = null, double? price = null, string? orderBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            // Filtering
            if (title != null)
            {
                result = result.Where(book => book.Title.Contains(title));
            }
            if (price != null)
            {
                result = result.Where(book => book.Price >= price);
            }

            // Ordering
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title":
                    case "title_asc":
                        result = result.OrderBy(book => book.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(book => book.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(book => book.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(book => book.Price);
                        break;
                    default:
                        return result;
                }
            }

            return result;
        }

        public Book? GetById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Remove(int id)
        {
            Book? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? Update(int id, Book book)
        {
            Book? existingBook = GetById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            return existingBook;
        }
    }
}
