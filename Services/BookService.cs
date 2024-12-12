using bookstore.Database;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> Get();
        public Task<Book> Get(Guid guid);
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


        public async Task<IEnumerable<Book>> Get()
        {
            _logger.LogDebug("Fetching books from database");

            var books = await _dbContext.BookEntities
                .Select(book => new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                }).ToListAsync();
            _logger.LogDebug("{Amount} books fetched", books.Count);
            return books;
        }

        public async Task<Book?> Get(Guid guid)
        {
            _logger.LogDebug("Fetching book {Id} from database", guid);

            Book? book = await _dbContext.BookEntities
                .Where(b => b.Id == guid)
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                })
                .FirstOrDefaultAsync();
            _logger.LogDebug("{Amount} books fetched", book);
            return book;
        }
    }
}
