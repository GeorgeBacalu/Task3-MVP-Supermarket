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
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISoldProductRepository _soldProductRepository;
        private readonly IStockRepository _stockRepository;

        public ReceiptService(IReceiptRepository receiptRepository, IUserRepository userRepository, ISoldProductRepository soldProductRepository, IStockRepository stockRepository)
            => (_receiptRepository, _userRepository, _soldProductRepository, _stockRepository) = (receiptRepository, userRepository, soldProductRepository, stockRepository);

        public IList<ReceiptDto> GetAll() => _receiptRepository.GetAll().ToDtos();

        public ReceiptDto GetById(Guid id) => _receiptRepository.GetById(id).ToDto();

        public ReceiptDto Add(ReceiptDto receiptDto) => _receiptRepository.Add(receiptDto.ToEntity(_userRepository, _soldProductRepository, _stockRepository)).ToDto();

        public ReceiptDto UpdateById(ReceiptDto receiptDto, Guid id)
        {
            Receipt updatedReceipt = _receiptRepository.UpdateById(receiptDto.ToEntity(_userRepository, _soldProductRepository, _stockRepository), id);
            updatedReceipt.Issuer = _userRepository.GetById(receiptDto.IssuerId);
            updatedReceipt.SoldProducts = receiptDto.SoldProductsIds.Select(_soldProductRepository.GetById).ToList();
            updatedReceipt.Stocks = receiptDto.StocksIds.Select(_stockRepository.GetById).ToList();
            return updatedReceipt.ToDto();
        }

        public ReceiptDto DeleteById(Guid id) => _receiptRepository.DeleteById(id).ToDto();
    }
}