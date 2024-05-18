using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetAll();

        User GetById(Guid id);

        User Add(User user);

        User UpdateById(User user, Guid id);
        
        User DeleteById(Guid id);
    }
}