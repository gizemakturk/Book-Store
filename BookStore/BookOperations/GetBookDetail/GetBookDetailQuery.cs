﻿using BookStore.Common;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
      
        private readonly BookStoreDbContext _dbContext; 
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı ");
            BookDetailViewModel vm = new BookDetailViewModel();
           vm.Title=book.Title;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            vm.Genre =((GenreEnum)book.GenreId).ToString();
            vm.PageCount=book.PageCount;
            
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }
}
