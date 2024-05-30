using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public StockService(IStockRepository stockRepository, IProductRepository productRepository) => (_stockRepository, _productRepository) = (stockRepository, productRepository);

        public IList<StockDto> GetAll() => _stockRepository.GetAll().ToDtos();

        public IList<StockDto> GetByKey(string key) => _stockRepository.GetByProductNameContains(key).ToDtos();

        public StockDto GetById(Guid id) => _stockRepository.GetById(id).ToDto();

        public StockDto Add(StockDto stockDto) => _stockRepository.Add(stockDto.ToEntity(_productRepository)).ToDto();

        public StockDto UpdateById(StockDto stockDto, Guid id) => _stockRepository.UpdateById(stockDto.ToEntity(_productRepository), id).ToDto();

        public StockDto DeleteById(Guid id) => _stockRepository.DeleteById(id).ToDto();
    }
}