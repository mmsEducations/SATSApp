using FluentValidation;

namespace SATSApp.Business.Validations
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.FirstName)
                   .NotEmpty().WithMessage("First name is required")
                   .Length(2, 50).WithMessage("First name must be 2 and 50 charecters");


            RuleFor(x => x.LastName)
                   .NotEmpty().WithMessage("Last name is required")
                   .Length(2, 50).WithMessage("Last name must be 2 and 50 charecters");

            RuleFor(x => x.BirthDate)
                   .LessThan(DateTime.Now).WithMessage("Birth date must be in he past");

            RuleFor(x => x.Email)
                  .NotEmpty().WithMessage("Email is required")
                  .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.City)
                 .NotEmpty().WithMessage("City name is required");

        }
    }
}
