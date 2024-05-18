using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        IList<Receipt> GetAll();

        Receipt GetById(Guid id);

        Receipt Add(Receipt receipt);

        Receipt UpdateById(Receipt receipt, Guid id);

        Receipt DeleteById(Guid id);
    }
}