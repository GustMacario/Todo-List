using FluentValidation;
using ToDoList.Models;
namespace ToDoList.Utils.Validators

{
    public class ToDoRequestModelValidator : AbstractValidator<ToDoRequestModel>
    {
        public ToDoRequestModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Name is a required field.");

            RuleFor(x => x.Description)
                .NotNull().NotEmpty()
                .WithMessage("Description is a required field.");

            RuleFor(x => x.ExpectedDate)
                .NotNull().NotEmpty()
                .WithMessage("ExpectedDate is a required field.");

            RuleFor(x => x.Priority)
                .NotNull()
                .WithMessage("Priority is a required field.");
        }
    }
}
