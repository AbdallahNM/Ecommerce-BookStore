using BookStore.Models;

namespace BookStore.Repository.Interfaces
{
    public interface IBookRepository
    {
        Book Get(int id);
        IEnumerable<Book> GetAll();
        Book Add(Book book);
        Book update(Book bookChanges);
        Book Delete(int id);
    }
}
