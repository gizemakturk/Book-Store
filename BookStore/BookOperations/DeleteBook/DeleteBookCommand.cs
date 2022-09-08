using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public DeleteBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
          
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book != null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }
        public class DeleteBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }

    }
}
