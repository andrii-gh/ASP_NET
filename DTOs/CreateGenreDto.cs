using System.ComponentModel.DataAnnotations;

namespace _02.DTOs
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}