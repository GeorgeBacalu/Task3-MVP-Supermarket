using Supermarket.Core.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IManufacturerService
    {
        IList<ManufacturerDto> GetAll();

        IList<ManufacturerDto> GetByKey(string key);

        ManufacturerDto GetById(Guid id);

        ManufacturerDto Add(ManufacturerDto manufacturerDto);

        ManufacturerDto UpdateById(ManufacturerDto manufacturerDto, Guid id);

        ManufacturerDto DeleteById(Guid id);
    }
}