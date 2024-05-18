using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IReceiptRepository _receiptRepository;

        public StockService(IStockRepository stockRepository, IReceiptRepository receiptRepository) => (_stockRepository, _receiptRepository) = (stockRepository, receiptRepository);

        public IList<StockDto> GetAll() => _stockRepository.GetAll().ToDtos();

        public StockDto GetById(Guid id) => _stockRepository.GetById(id).ToDto();

        public StockDto Add(StockDto stockDto) => _stockRepository.Add(stockDto.ToEntity(_receiptRepository)).ToDto();

        public StockDto UpdateById(StockDto stockDto, Guid id)
        {
            Stock updatedStock = _stockRepository.UpdateById(stockDto.ToEntity(_receiptRepository), id);
            updatedStock.Receipts = stockDto.ReceiptsIds.Select(_receiptRepository.GetById).ToList();
            return updatedStock.ToDto();
        }

        public StockDto DeleteById(Guid id) => _stockRepository.DeleteById(id).ToDto();
    }
}