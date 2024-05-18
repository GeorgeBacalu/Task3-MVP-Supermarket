using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface ISoldProductService
    {
        IList<SoldProductDto> GetAll();

        SoldProductDto GetById(Guid id);

        SoldProductDto Add(SoldProductDto soldProductDto);

        SoldProductDto UpdateById(SoldProductDto soldProductDto, Guid id);

        SoldProductDto DeleteById(Guid id);
    }
}