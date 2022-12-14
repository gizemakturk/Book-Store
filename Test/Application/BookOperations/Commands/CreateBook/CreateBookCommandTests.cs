using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.DBOperations;
using BookStore.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TestSetup;
using Xunit;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace Test.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests (CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
         public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (hazırlık)
            var book = new Book()
            {
                Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate = new System.DateTime(1999, 01, 01),
                GenreId=1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act & assert(calıstırma & doğrulama)

            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("kitap zaten mevcut.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model =new CreateBookModel() { Title = "Hobbit",PageCount=1000,PublishDate = DateTime.Now.Date.AddYears(-10),GenreId=1};
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
           // book.Title.Should().Be(model.Title);
            book.GenreId.Should().Be(model.GenreId);
        }   
    }
}
