using bookstore.Models;
using bookstore.Models.Dtos;

namespace bookstore.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> Get();
    }

    public class BookService : IBookService
    {
        public IEnumerable<Book> Get()
        {
            var exampleBook = new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Example"
            };
            return [exampleBook];
        }
    }
}
