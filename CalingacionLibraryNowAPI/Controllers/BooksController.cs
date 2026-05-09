using CalingacionLibraryNowAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalingacionLibraryNowAPI.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Books> books = new List<Books>
        {
            new Books
            {
                Id = 1,
                Title = "Empire of Storms",
                Author = "Sarah J. Maas",
                Genre = "Magic",
                Available = true,
                PublishedYear = 2016
            },
            new Books
            {
                Id = 2,
                Title = "The Autobiography of Benjamin Franklin",
                Author = "Benjamin Franklin",
                Genre = "Scientists",
                Available = true,
                PublishedYear = 2016
            }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = books,
                message = "Books retrieved."
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."
                });
            }

            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book retrieved."
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Books newBook)
        {
            newBook.Id = books.Count + 1;

            books.Add(newBook);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newBook.Id },
                new
                {
                    status = "success",
                    data = newBook,
                    message = "Book created."
                });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Books updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."
                });
            }

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Genre = updateBook.Genre;
            book.Available = updateBook.Available;
            book.PublishedYear = updateBook.PublishedYear;

            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book updated."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."
                });
            }

            books.Remove(book);

            return Ok(new
            {
                status = "success",
                data = (object?)null,
                message = "Book deleted."
            });
        }
    }
}
