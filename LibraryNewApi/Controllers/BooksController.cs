using LibraryManagmentAPI;
using LibraryNewApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class BooksController : ControllerBase
    {
        private readonly EFDataContext _context;

        public BooksController(EFDataContext context)
        {
            _context = context;
        }

        [HttpPost("set-books")]
        public int Add(AddBookDto dto)
        {
            var book = new Book
            {
                Name = dto.Name,
                Genre = dto.Genre,
                Writer = dto.Writer
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return book.Id;

        }

        [HttpGet("get-books")]
        public List<GetBookDto> GetBooks([FromQuery] string bookname = null, [FromQuery] string bookgenre = null)
        {
            var books = _context.Books
                .Select(_ => new GetBookDto
                {
                    Name = _.Name,
                    Id = _.Id,
                    Genre = _.Genre,
                    Writer = _.Writer

                })
                .ToList();
            if (bookname != null)
            {
                books = books.Where(_ => _.Name == bookname).ToList();
                return books;
            }
            if (bookgenre != null)
            {
                books = books.Where(_ => _.Genre == bookgenre).ToList();
                return books;
            }

            return books;

        }
        [HttpPut("update-books")]
        public void UpdateBooks([FromQuery]int id,[FromBody]UpdateBooksDto dto)
        {
            var book = _context.Books.Where(_ => _.Id == id).First();
            book.Name = dto.Name;
            book.Genre = dto.Genre;
            book.Writer = dto.Writer;
            _context.SaveChanges();
        }
        [HttpDelete("delete-books")]
        public void DeletBooks([FromQuery]int id)
        {
            var book = _context.Books.FirstOrDefault(_ => _.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}

