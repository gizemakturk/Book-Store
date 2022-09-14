using BookStore.BookOperations.CreateBook;
using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
           
            RuleFor(command => command.Model.Dob).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);


        }
    }
}
