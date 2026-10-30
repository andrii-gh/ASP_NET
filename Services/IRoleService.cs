using _02.DTOs;

namespace _02.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<bool> UpdateAsync(int id, CreateRoleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}