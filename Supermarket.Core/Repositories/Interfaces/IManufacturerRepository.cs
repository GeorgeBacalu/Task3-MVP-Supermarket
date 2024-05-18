using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IManufacturerRepository
    {
        IList<Manufacturer> GetAll();

        Manufacturer GetById(Guid id);

        Manufacturer Add(Manufacturer manufacturer);

        Manufacturer UpdateById(Manufacturer manufacturer, Guid id);

        Manufacturer DeleteById(Guid id);
    }
}