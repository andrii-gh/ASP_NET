using _02.DTOs;
using FluentValidation;

namespace _02.Validators
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorWithFileDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ім'я є обов'язковим")
                .MinimumLength(2).WithMessage("Ім'я має містити щонайменше 2 символи")
                .MaximumLength(50).WithMessage("Ім'я не може перевищувати 50 символів");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Прізвище є обов'язковим")
                .MinimumLength(2).WithMessage("Прізвище має містити щонайменше 2 символи")
                .MaximumLength(50).WithMessage("Прізвище не може перевищувати 50 символів");

            RuleFor(x => x.Nationality)
                .NotEmpty().WithMessage("Національність є обов'язковою");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Дата народження є обов'язковою")
                .LessThan(DateTime.Now).WithMessage("Дата народження не може бути в майбутньому")
                .GreaterThan(new DateTime(1900, 1, 1)).WithMessage("Дата народження занадто давня");

            RuleFor(x => x.Biography)
                .MaximumLength(1000).WithMessage("Біографія не може перевищувати 1000 символів");

            RuleFor(x => x.ImageFile)
                .Must(file => file == null || file.Length <= 5 * 1024 * 1024)
                .WithMessage("Розмір файлу не може перевищувати 5 МБ")
                .Must(file => file == null || file.ContentType.StartsWith("image/"))
                .WithMessage("Файл має бути зображенням (jpg, png тощо)");
        }
    }
}