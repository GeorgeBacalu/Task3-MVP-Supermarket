using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface ISoldProductRepository
    {
        IList<SoldProduct> GetAll();

        SoldProduct GetById(Guid id);

        SoldProduct Add(SoldProduct soldProduct);

        SoldProduct UpdateById(SoldProduct soldProduct, Guid id);

        SoldProduct DeleteById(Guid id);
    }
}