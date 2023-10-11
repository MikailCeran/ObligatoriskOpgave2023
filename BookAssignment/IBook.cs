using BookAssignment;

namespace BookAssignment
{
    public interface Ibook
    {
        Book Add(Book book);
        IEnumerable<Book> Get(string? Title = null, double? Price = null, string? orderBy = null);
        Book? GetById(int id);
        Book? Remove(int id);
        Book? Update(int id, Book book);
    }
}