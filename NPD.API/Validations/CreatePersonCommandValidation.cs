using FluentValidation;
using NPD.API.Application.Commands;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Extensions;
using System;

namespace NPD.API.Validations
{
    public class CreatePersonCommandValidation : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidation()
        {
            RuleFor(x => x.Firstname).Must(x => x.IsLatinOrGeorgian() == true).WithMessage("The firstname should contain characters only from the English and Georgian alphabet, but not simultaneously");
            RuleFor(x => x.Lastname).Must(x => x.IsLatinOrGeorgian() == true).WithMessage("The lastname should contain characters only from the English and Georgian alphabet, but not simultaneously");
            RuleFor(x => x.Gender).Must(x => Enum.IsDefined(typeof(Gender), x));
        }
    }
}
