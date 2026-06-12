using FluentValidation;
using Taskei.Application.DTOs;

namespace Taskei.Application.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");

            RuleFor(x => x.Username)
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters long.");

            RuleFor(x => x.Username)
            .MaximumLength(100)
            .WithMessage("Username must not exceed 100 characters.");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
        }
    }
}