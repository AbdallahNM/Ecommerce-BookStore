using BookStore.Context;
using BookStore.Models;
using BookStore.Repository.Interfaces;

namespace BookStore.Repository.Implementation
{
    public class BookRepository : IBookRepository   
    {
        private readonly BookStoreDBContext context;

        public BookRepository(BookStoreDBContext context)
        {
            this.context = context;
        }

        public Book Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            Book book = context.Books.Find(id);
            if(book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return book;
        }

        public Book Get(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Book update(Book bookChanges)
        {
            var book = context.Books.Attach(bookChanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookChanges;
        }
    }
}
