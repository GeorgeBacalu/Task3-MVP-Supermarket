using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IStockService
    {
        IList<StockDto> GetAll();

        StockDto GetById(Guid id);

        StockDto Add(StockDto stockDto);

        StockDto UpdateById(StockDto stockDto, Guid id);

        StockDto DeleteById(Guid id);
    }
}