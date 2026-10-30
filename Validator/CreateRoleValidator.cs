using _02.DTOs;
using FluentValidation;

namespace _02.Validators
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назва ролі обов'язкова")
                .MinimumLength(2).WithMessage("Назва ролі має містити щонайменше 2 символи")
                .MaximumLength(50).WithMessage("Назва ролі не може перевищувати 50 символів")
                .Matches("^[a-zA-Zа-яА-ЯіІїЇєЄ0-9_ ]+$").WithMessage("Назва може містити лише літери, цифри, пробіли та підкреслення");
        }
    }
}