using bookstore.Database;
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
        private readonly ILogger<BookService> _logger;
        private readonly BookstoreDbContext _dbContext;

        public BookService(ILogger<BookService> logger,
            BookstoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public IEnumerable<Book> Get()
        {
            _logger.LogDebug("Fetching books from database");

            var books = _dbContext.BookEntities
                .Select(book => new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                }).ToList();
            _logger.LogDebug("{Amount} books fetched", books.Count);
            return books;
        }
    }
}
