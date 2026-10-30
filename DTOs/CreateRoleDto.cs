using System.ComponentModel.DataAnnotations;

namespace _02.DTOs
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Назва ролі обов'язкова")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Назва ролі має бути від 2 до 50 символів")]
        public string Name { get; set; } = string.Empty;
    }
}