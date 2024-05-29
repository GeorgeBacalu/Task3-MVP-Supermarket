using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Dtos.Request;
using Supermarket.Core.Entities;
using Supermarket.Core.Extensions;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository) => (_userRepository, _roleRepository) = (userRepository, roleRepository);

        public IList<UserDto> GetAll() => _userRepository.GetAll().ToDtos();

        public UserDto GetById(Guid id) => _userRepository.GetById(id).ToDto();

        public UserDto Register(RegisterRequest payload)
        {
            if (payload == null) throw new Exception("Null payload provided");
            byte[] salt = PasswordExtensions.GenerateSalt();
            return _userRepository.Add(new User
            {
                Name = payload.Name,
                Email = payload.Email,
                Role = _roleRepository.GetById(payload.RoleId),
                PasswordHash = PasswordExtensions.HashPassword(payload.Password, salt),
                PasswordSalt = Convert.ToBase64String(salt),
                CreatedAt = DateTime.Now
            }).ToDto();
        }

        public UserDto Login(LoginRequest payload)
        {
            if (payload == null) throw new Exception("Null payload provided");
            User user = _userRepository.GetByEmail(payload.Email);
            return user == null ? throw new Exception("Invalid email") :
                !PasswordExtensions.CheckPassword(payload.Password, user.PasswordHash, user.PasswordSalt) ? throw new Exception("Incorrect password") : user.ToDto();
        }

        public UserDto UpdateById(UserDto userDto, Guid id) => _userRepository.UpdateById(userDto.ToEntity(_roleRepository), id).ToDto();

        public UserDto DeleteById(Guid id) => _userRepository.DeleteById(id).ToDto();
    }
}