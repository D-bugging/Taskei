using FluentValidation;
using Taskei.API.DTOs;

namespace Taskei.API.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required for creating a task.");

            RuleFor(x => x.Title)
            .MinimumLength(3)
            .WithMessage("Title must be at least 3 characters long.");

            RuleFor(x => x.Title)
            .MaximumLength(100)
            .WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
            .MaximumLength(500);

            RuleFor(x => x.Priority)
            .InclusiveBetween(1, 3)
            .WithMessage("Priority must be between 1 (Low) and 3 (High).");
        }
    }
}