﻿using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class ReceiptMappingExtensions
    {
        public static IList<ReceiptDto> ToDtos(this IList<Receipt> receipts) => receipts.Select(receipt => receipt.ToDto()).ToList();

        public static IList<Receipt> ToEntities(this IList<ReceiptDto> receiptDtos, IUserRepository userRepository, ISoldProductRepository soldProductRepository, IStockRepository stockRepository)
            => receiptDtos.Select(receiptDto => receiptDto.ToEntity(userRepository, soldProductRepository, stockRepository)).ToList();

        public static ReceiptDto ToDto(this Receipt receipt) => new ReceiptDto
        {
            Id = receipt.Id,
            IssuedAt = receipt.IssuedAt,
            IssuerId = receipt.Issuer.Id,
            SoldProductsIds = receipt.SoldProducts.Select(soldProduct => soldProduct.Id).ToList(),
            Total = receipt.Total,
            StocksIds = receipt.Stocks.Select(stock => stock.Id).ToList(),
            CreatedAt = receipt.CreatedAt,
            UpdatedAt = receipt.UpdatedAt,
            DeletedAt = receipt.DeletedAt
        };

        public static Receipt ToEntity(this ReceiptDto receiptDto, IUserRepository userRepository, ISoldProductRepository soldProductRepository, IStockRepository stockRepository) => new Receipt
        {
            Id = receiptDto.Id,
            IssuedAt = receiptDto.IssuedAt,
            Issuer = userRepository.GetById(receiptDto.IssuerId),
            SoldProducts = receiptDto.SoldProductsIds.Select(soldProductRepository.GetById).ToList(),
            Total = receiptDto.Total,
            Stocks = receiptDto.StocksIds.Select(stockRepository.GetById).ToList(),
            CreatedAt = receiptDto.CreatedAt,
            UpdatedAt = receiptDto.UpdatedAt,
            DeletedAt = receiptDto.DeletedAt
        };
    }
}