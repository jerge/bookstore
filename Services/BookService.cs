using bookstore.Database;
using bookstore.Database.Entities;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> Get();
        public Task<Book?> Get(Guid guid);
        public Task<bool> Create(Book book);
        public Task<bool> Update(Guid guid, string title);
        public Task<bool> Delete(Guid guid);
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

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>All books in the database</returns>
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

        /// <summary>
        /// Gets a specific book by its id
        /// </summary>
        /// <param name="guid">Book id to get</param>
        /// <returns>The book if it exists</returns>
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

        /// <summary>
        /// Tries to add a book to the database
        /// </summary>
        /// <param name="book">book to add</param>
        /// <returns>If the book was succesfully added</returns>
        public async Task<bool> Create(Book book)
        {
            _logger.LogDebug("Adding book with id {Id}", book.Id);

            BookEntity entity = new()
            {
                Id = book.Id,
                Title = book.Title,
            };

            Book? existingBook = await Get(book.Id);

            if (existingBook != null)
            {
                _logger.LogWarning("Trying to insert book that already exists {Id}", book.Id);
                return false;
            }
            _dbContext.BookEntities.Add(entity);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        /// <summary>
        /// Updates the title of a book
        /// </summary>
        /// <param name="guid">Book to update</param>
        /// <param name="title">Desired title</param>
        /// <returns>If the update was successful</returns>
        public async Task<bool> Update(Guid guid, string title)
        {
            var bookToUpdate = await _dbContext.BookEntities.FindAsync(guid);

            if (bookToUpdate == null)
            {
                return false;
            }

            bookToUpdate.Title = title;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Deletes a specific book
        /// </summary>
        /// <param name="guid">The book to delete</param>
        /// <returns>If the deletion was succesful</returns>
        public async Task<bool> Delete(Guid guid)
        {
            var bookToDelete = await _dbContext.BookEntities.FindAsync(guid);

            if (bookToDelete == null)
            {
                return false;
            }

            _dbContext.BookEntities.Remove(bookToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
