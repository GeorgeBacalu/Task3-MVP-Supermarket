using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class StockMappingExtensions
    {
        public static IList<StockDto> ToDtos(this IList<Stock> stocks) => stocks.Select(stock => stock.ToDto()).ToList();

        public static IList<Stock> ToEntities(this IList<StockDto> stockDtos, IProductRepository productRepository) => stockDtos.Select(stockDto => stockDto.ToEntity(productRepository)).ToList();

        public static StockDto ToDto(this Stock stock) => stock == null ? null : new StockDto
        {
            Id = stock.Id,
            ProductId = stock.Product?.Id ?? Guid.Empty,
            Quantity = stock.Quantity,
            MeasureUnit = stock.MeasureUnit,
            SuppliedAt = stock.SuppliedAt,
            ExpiresAt = stock.ExpiresAt,
            PurchasePrice = stock.PurchasePrice,
            SalePrice = stock.SalePrice,
            TradeMarkup = stock.TradeMarkup,
            CreatedAt = stock.CreatedAt,
            UpdatedAt = stock.UpdatedAt,
            DeletedAt = stock.DeletedAt
        };

        public static Stock ToEntity(this StockDto stockDto, IProductRepository productRepository) => stockDto == null ? null : new Stock
        {
            Id = stockDto.Id,
            Product = stockDto.ProductId == Guid.Empty ? null : productRepository.GetById(stockDto.ProductId),
            Quantity = stockDto.Quantity,
            MeasureUnit = stockDto.MeasureUnit,
            SuppliedAt = stockDto.SuppliedAt,
            ExpiresAt = stockDto.ExpiresAt,
            PurchasePrice = stockDto.PurchasePrice,
            SalePrice = stockDto.SalePrice,
            TradeMarkup = stockDto.TradeMarkup,
            CreatedAt = stockDto.CreatedAt,
            UpdatedAt = stockDto.UpdatedAt,
            DeletedAt = stockDto.DeletedAt
        };
    }
}