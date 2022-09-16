using AutoMapper;
using BookStore.BookOperations_GetBooks;
using BookStore.DBOperations;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authorslist = _context.Authors.Include(x => x.Books).ThenInclude(x => x.Genre).OrderBy(x => x.Id).ToList<Author>();
           
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authorslist);
            return returnObj;
        }
    }
    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime Dob { get; set; }
        public ICollection<BooksWithoutAuthorViewModel> Books { get; set; }
    }
}
