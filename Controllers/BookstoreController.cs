using bookstore.Models;
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
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            _logger.LogDebug("Getting all books");

            var books = await _bookService.Get();

            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            _logger.LogDebug("Getting book {Id}", id);

            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
