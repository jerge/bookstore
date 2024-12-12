using bookstore.Models;
using bookstore.Models.Dtos;
using bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookstoreController : ControllerBase
    {
        private readonly ILogger<BookstoreController> _logger;
        private readonly IBookService _bookService;

        public BookstoreController(ILogger<BookstoreController> logger,
            IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<BookDto> Get()
        {
            _logger.LogDebug("Getting all books");

            var books = _bookService.Get()
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                });

            return  books;
        }
    }
}
