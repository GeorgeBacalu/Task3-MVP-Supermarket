using Supermarket.Core.Dtos.Common;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IRoleService
    {
        IList<RoleDto> GetAll();

        RoleDto GetById(int id);

        RoleDto Add(RoleDto roleDto);
    }
}