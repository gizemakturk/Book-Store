using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
      
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı ");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);  //new BookDetailViewModel();
           //vm.Title=book.Title;
           // vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
           // vm.Genre =((GenreEnum)book.GenreId).ToString();
           // vm.PageCount=book.PageCount;
            
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        
        public string Author { get; set; }
    }
}

