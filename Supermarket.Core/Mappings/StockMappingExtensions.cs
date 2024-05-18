using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class StockMappingExtensions
    {
        public static IList<StockDto> ToDtos(this IList<Stock> stocks) => stocks.Select(stock => stock.ToDto()).ToList();

        public static IList<Stock> ToEntities(this IList<StockDto> stockDtos, IReceiptRepository receiptRepository) => stockDtos.Select(stockDto => stockDto.ToEntity(receiptRepository)).ToList();

        public static StockDto ToDto(this Stock stock) => new StockDto
        {
            Id = stock.Id,
            Quantity = stock.Quantity,
            MeasureUnit = stock.MeasureUnit,
            SuppliedAt = stock.SuppliedAt,
            ExpiresAt = stock.ExpiresAt,
            PurchasePrice = stock.PurchasePrice,
            SalePrice = stock.SalePrice,
            ReceiptsIds = stock.Receipts.Select(receipt => receipt.Id).ToList(),
            CreatedAt = stock.CreatedAt,
            UpdatedAt = stock.UpdatedAt,
            DeletedAt = stock.DeletedAt
        };

        public static Stock ToEntity(this StockDto stockDto, IReceiptRepository receiptRepository) => new Stock
        {
            Id = stockDto.Id,
            Quantity = stockDto.Quantity,
            MeasureUnit = stockDto.MeasureUnit,
            SuppliedAt = stockDto.SuppliedAt,
            ExpiresAt = stockDto.ExpiresAt,
            PurchasePrice = stockDto.PurchasePrice,
            SalePrice = stockDto.SalePrice,
            Receipts = stockDto.ReceiptsIds.Select(receiptRepository.GetById).ToList(),
            CreatedAt = stockDto.CreatedAt,
            UpdatedAt = stockDto.UpdatedAt,
            DeletedAt = stockDto.DeletedAt
        };
    }
}