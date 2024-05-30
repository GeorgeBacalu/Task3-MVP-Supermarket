using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IList<Product> GetAll();

        IList<Product> GetByNameContains(string name);

        Product GetById(Guid id);

        Product Add(Product product);

        Product UpdateById(Product product, Guid id);

        Product DeleteById(Guid id);
    }
}