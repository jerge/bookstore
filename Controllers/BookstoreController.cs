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

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Create(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
            {
                return BadRequest("Book requires a non empty title");
            }
            _logger.LogDebug("Adding book with id {Id}", book.Id);

            var success = await _bookService.Create(book);

            if (!success)
            {
                return Conflict();
            }
            return Created(string.Empty, null);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Create(Guid id, string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Book requires a non empty title");
            }
            _logger.LogDebug("Updating book with id {Id}", id);

            var success = await _bookService.Update(id, title);

            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            _logger.LogDebug("Deleting book with id {Id}", id);

            var success = await _bookService.Delete(id);

            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
