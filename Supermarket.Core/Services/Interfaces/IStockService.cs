using Supermarket.Core.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IStockService
    {
        IList<StockDto> GetAll();

        IList<StockDto> GetByKey(string key);

        StockDto GetById(Guid id);

        StockDto Add(StockDto stockDto);

        StockDto UpdateById(StockDto stockDto, Guid id);

        StockDto DeleteById(Guid id);
    }
}