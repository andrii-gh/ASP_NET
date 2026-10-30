using _02.DTOs;
using _02.Models;
using _02.Repositories;

namespace _02.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Select(r => new RoleDto { Id = r.Id, Name = r.Name });
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return null;
            return new RoleDto { Id = role.Id, Name = role.Name };
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            if (await _roleRepository.ExistsByNameAsync(dto.Name))
                throw new InvalidOperationException("Роль з такою назвою вже існує");

            var role = new Role { Name = dto.Name };
            await _roleRepository.AddAsync(role);

            return new RoleDto { Id = role.Id, Name = role.Name };
        }

        public async Task<bool> UpdateAsync(int id, CreateRoleDto dto)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;

            if (!role.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
            {
                if (await _roleRepository.ExistsByNameAsync(dto.Name))
                    throw new InvalidOperationException("Роль з такою назвою вже існує");
            }

            role.Name = dto.Name;
            await _roleRepository.UpdateAsync(role);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;

            await _roleRepository.DeleteAsync(id);
            return true;
        }
    }
}