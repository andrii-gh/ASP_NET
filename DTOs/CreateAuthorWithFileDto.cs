using System.ComponentModel.DataAnnotations;

namespace _02.DTOs
{
    public class CreateAuthorWithFileDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }
    }
}