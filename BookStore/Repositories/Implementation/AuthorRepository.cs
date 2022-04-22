using BookStore.Context;
using BookStore.Models;
using BookStore.Repository.Interfaces;

namespace BookStore.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDBContext context;

        public AuthorRepository(BookStoreDBContext context)
        {
            this.context = context;
        }

       public Author  add(Author author)
        {
            
            context.Authors.Add(author);
            context.SaveChanges();
            return author;
        }

        public Author Delete(int id)
        {
            Author author = context.Authors.Find(id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return author;

        }

        public Author Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            return context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return context.Authors;
        }

        public Author update(Author authorChanges)
        {
            var author = context.Authors.Attach(authorChanges);
            author.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return authorChanges;
        }

       
    }
}
//public Author Add(Author author)
//{
//    context.Authors.Add(author);
//    context.SaveChanges();
//    return author;
//}