using _02.DTOs;
using _02.Models;

namespace _02.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto ToDto(Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static Role ToEntity(CreateRoleDto dto)
        {
            return new Role
            {
                Name = dto.Name
            };
        }
    }
}