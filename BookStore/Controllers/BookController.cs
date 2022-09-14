using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.UpdateBook;
using BookStore.BookOperations_GetBooks;
using BookStore.DBOperations;
using BookStore.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // private static List<Book> BookList = new List<Book>();
        //
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            //var booklist=_context.Books.OrderBy(x=>x.Id).ToList<Book>();
            //  return booklist;
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        //route
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            BookDetailViewModel result;
          
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
               result=  query.Handle();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            
            return Ok(result);
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
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
          
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
               validator.ValidateAndThrow(command);
                command.Handle();


                //if (!result.IsValid)
                //{
                //    foreach(var item in result.Errors)
                //    {
                //        Console.WriteLine("Özellik:"+ item.PropertyName + "- Error Message: " + item.ErrorMessage);
                //    }
                //}
                //else 
                //command.Handle();

            
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //var book=_context.Books.SingleOrDefault(x=>x.Title==newBook.Title);
            //if (book is not null)
            //    return BadRequest();
            //_context.Books.Add(newBook);
            //_context.SaveChanges();
            return Ok();    

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
          
              
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();   
            //   }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            //if(book is null )
            //    return BadRequest();

            //book.Title = updatedBook.Title !=default ? updatedBook.Title : book.Title;
            //book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            //book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            //book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            //_context.SaveChanges();

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
           
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //var book= _context.Books.SingleOrDefault(x=>x.Id == id);
            //if (book != null)
            //    return BadRequest();

            //_context.Books.Remove(book);
            //_context.SaveChanges();

            return Ok();
        }
    }
}
