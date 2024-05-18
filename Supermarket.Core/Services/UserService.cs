using Supermarket.Core.Dtos;
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

        public UserDto Add(UserDto userDto) => _userRepository.Add(userDto.ToEntity(_roleRepository)).ToDto();

        public UserDto UpdateById(UserDto userDto, Guid id) => _userRepository.UpdateById(userDto.ToEntity(_roleRepository), id).ToDto();

        public UserDto DeleteById(Guid id) => _userRepository.DeleteById(id).ToDto();
    }
}