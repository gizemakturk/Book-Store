using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations_GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle() {
            var booklist = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booklist);//new List<BooksViewModel>();
           // foreach (var book in booklist)
           // {
           //     vm.Add(new BooksViewModel()
           //     {
           //         Title = book.Title,
           //         Genre = ((GenreEnum)book.GenreId).ToString(),
           //         PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
           //         PageCount = book.PageCount,
           //     });
           // }
            return vm;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }
         public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }
}
