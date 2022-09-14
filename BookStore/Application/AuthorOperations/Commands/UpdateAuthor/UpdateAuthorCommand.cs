using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId); ;
            if (author is null)
                throw new InvalidOperationException(" Güncellenecek yazar bulunamadı ");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.BookId = Model.BookoId != default ? Model.BookId : author.BookId;
            
            _dbContext.SaveChanges();


        }


        public class UpdateAuthorModel
        {
            public string Name { get; set; }
           
        }

    }
}

