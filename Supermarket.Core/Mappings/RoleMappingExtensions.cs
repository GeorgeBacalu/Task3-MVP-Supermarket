using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class RoleMappingExtensions
    {
        public static IList<RoleDto> ToDtos(this IList<Role> roles) => roles.Select(role => role.ToDto()).ToList();

        public static IList<Role> ToEntities(this IList<RoleDto> roleDtos) => roleDtos.Select(roleDto => roleDto.ToEntity()).ToList();

        public static RoleDto ToDto(this Role role) => role == null ? null : new RoleDto
        {
            Id = role.Id,
            Type = role.Type,
            CreatedAt = role.CreatedAt,
            UpdatedAt = role.UpdatedAt,
            DeletedAt = role.DeletedAt
        };

        public static Role ToEntity(this RoleDto roleDto) => roleDto == null ? null : new Role
        {
            Id = roleDto.Id,
            Type = roleDto.Type,
            CreatedAt = roleDto.CreatedAt,
            UpdatedAt = roleDto.UpdatedAt,
            DeletedAt = roleDto.DeletedAt
        };
    }
}