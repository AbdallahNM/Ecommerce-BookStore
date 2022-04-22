using BookStore.Models;

namespace BookStore.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Author Get(int id);
        IEnumerable <Author> GetAll();
        Author add(Author author);
        Author update(Author author);
        Author Delete(Author author);
    }
}
