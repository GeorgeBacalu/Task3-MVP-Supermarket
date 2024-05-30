using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class ProductMappingExtensions
    {
        public static IList<ProductDto> ToDtos(this IList<Product> products) => products.Select(product => product.ToDto()).ToList();

        public static IList<Product> ToEntites(this IList<ProductDto> productDtos, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository, IStockRepository stockRepository) => 
            productDtos.Select(productDto => productDto.ToEntity(categoryRepository, manufacturerRepository, stockRepository)).ToList();

        public static ProductDto ToDto(this Product product) => product == null ? null : new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            BarCode = product.BarCode,
            CategoryId = product.Category?.Id ?? Guid.Empty,
            ManufacturerId = product.Manufacturer?.Id ?? Guid.Empty,
            StocksIds = product.Stocks?.Select(stock => stock.Id).ToList() ?? new List<Guid>(),
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            DeletedAt = product.DeletedAt
        };

        public static Product ToEntity(this ProductDto productDto, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository, IStockRepository stockRepository) => productDto == null ? null : new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            BarCode = productDto.BarCode,
            Category = productDto.CategoryId == Guid.Empty ? null : categoryRepository.GetById(productDto.CategoryId),
            Manufacturer = productDto.ManufacturerId == Guid.Empty ? null : manufacturerRepository.GetById(productDto.ManufacturerId),
            Stocks = productDto.StocksIds?.Select(stockRepository.GetById).ToList() ?? new List<Stock>(),
            CreatedAt = productDto.CreatedAt,
            UpdatedAt = productDto.UpdatedAt,
            DeletedAt = productDto.DeletedAt
        };
    }
}