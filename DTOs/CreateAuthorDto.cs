using System.ComponentModel.DataAnnotations;

namespace _02.DTOs
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Прізвище є обов'язковим")]
        public string LastName { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
    }
}