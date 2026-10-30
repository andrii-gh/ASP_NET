using _02.DTOs;

namespace _02.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<AuthorDto> CreateAsync(CreateAuthorWithFileDto dto);
        Task<bool> UpdateAsync(int id, CreateAuthorWithFileDto dto);
        Task<bool> DeleteAsync(int id);
    }
}