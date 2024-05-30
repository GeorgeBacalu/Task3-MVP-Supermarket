using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IStockRepository
    {
        IList<Stock> GetAll();

        IList<Stock> GetByProductNameContains(string name);

        Stock GetById(Guid id);

        Stock Add(Stock stock);

        Stock UpdateById(Stock stock, Guid id);

        Stock DeleteById(Guid id);
    }
}