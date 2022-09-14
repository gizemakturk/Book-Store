using AutoMapper;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations_GetBooks;
using BookStore.Models;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
        {

            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name) );
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

        }




    }
}
