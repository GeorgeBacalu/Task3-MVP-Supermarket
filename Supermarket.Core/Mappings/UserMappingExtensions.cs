using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class UserMappingExtensions
    {
        public static IList<UserDto> ToDtos(this IList<User> users) => users.Select(user => user.ToDto()).ToList();

        public static IList<User> ToEntities(this IList<UserDto> userDtos, IRoleRepository roleRepository) => userDtos.Select(userDto => userDto.ToEntity(roleRepository)).ToList();

        public static UserDto ToDto(this User user) => user == null ? null : new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt,
            RoleId = user.Role.Id,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            DeletedAt = user.DeletedAt
        };

        public static User ToEntity(this UserDto userDto, IRoleRepository roleRepository) => userDto == null ? null : new User
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = userDto.PasswordHash,
            PasswordSalt = userDto.PasswordSalt,
            Role = roleRepository.GetById(userDto.RoleId),
            CreatedAt = userDto.CreatedAt,
            UpdatedAt = userDto.UpdatedAt,
            DeletedAt = userDto.DeletedAt
        };
    }
}