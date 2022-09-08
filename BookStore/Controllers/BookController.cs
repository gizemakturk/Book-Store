using BookStore.BookOperations.CreateBook;

using BookStore.BookOperations_GetBooks;
using BookStore.DBOperations;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

       // private static List<Book> BookList = new List<Book>();
        //
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            //var booklist=_context.Books.OrderBy(x=>x.Id).ToList<Book>();
            //  return booklist;
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        //route
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book GetByID(int id)
        {
            var book=_context.Books.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }
        ////karısabilir ilki daha mantıklı
        ////query string 
        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}
        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //var book=_context.Books.SingleOrDefault(x=>x.Title==newBook.Title);
            //if (book is not null)
            //    return BadRequest();
            //_context.Books.Add(newBook);
            //_context.SaveChanges();
            return Ok();    

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if(book is null )
                return BadRequest();
           
            book.Title = updatedBook.Title !=default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
            var book= _context.Books.SingleOrDefault(x=>x.Id == id);
            if (book != null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
 
            return Ok();
        }
    }
}
