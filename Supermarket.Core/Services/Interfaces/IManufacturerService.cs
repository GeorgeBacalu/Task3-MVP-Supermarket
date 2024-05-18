using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IManufacturerService
    {
        IList<ManufacturerDto> GetAll();

        ManufacturerDto GetById(Guid id);

        ManufacturerDto Add(ManufacturerDto manufacturerDto);

        ManufacturerDto UpdateById(ManufacturerDto manufacturerDto, Guid id);

        ManufacturerDto DeleteById(Guid id);
    }
}