using AutoMapper;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations_GetBooks;
using BookStore.DBOperations;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.Include(x => x.Books).ThenInclude(x => x.Genre).Where(author => author.Id == AuthorId).SingleOrDefault();
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı ");
           AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);

            return vm;
        }
    }
    public class AuthorDetailViewModel
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime Dob { get; set; }
        public ICollection<BooksWithoutAuthorViewModel> Books { get; set; }
    }
}
 
