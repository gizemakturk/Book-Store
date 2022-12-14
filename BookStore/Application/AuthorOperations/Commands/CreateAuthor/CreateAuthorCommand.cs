using AutoMapper;
using BookStore.DBOperations;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut ");
            author = _mapper.Map<Author>(Model); 
         

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

        }
        public class CreateAuthorModel
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime Dob { get; set; }
           // public ICollection<Book> Books { get; set; }
        }

    }
}

