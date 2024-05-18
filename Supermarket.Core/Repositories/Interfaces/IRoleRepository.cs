using Supermarket.Core.Entities;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IList<Role> GetAll();

        Role GetById(int id);

        Role Add(Role role);
    }
}