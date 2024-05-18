using Supermarket.Core.Dtos;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public IList<RoleDto> GetAll() => _roleRepository.GetAll().ToDtos();

        public RoleDto GetById(int id) => _roleRepository.GetById(id).ToDto();

        public RoleDto Add(RoleDto roleDto) => _roleRepository.Add(roleDto.ToEntity()).ToDto();
    }
}