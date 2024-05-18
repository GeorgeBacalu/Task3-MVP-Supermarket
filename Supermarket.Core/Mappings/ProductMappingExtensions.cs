﻿using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class ProductMappingExtensions
    {
        public static IList<ProductDto> ToDtos(this IList<Product> products) => products.Select(product => product.ToDto()).ToList();

        public static IList<Product> ToEntites(this IList<ProductDto> productDtos, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository) => 
            productDtos.Select(productDto => productDto.ToEntity(categoryRepository, manufacturerRepository)).ToList();

        public static ProductDto ToDto(this Product product) => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            BarCode = product.BarCode,
            CategoryId = product.Category.Id,
            ManufacturerId = product.Manufacturer.Id,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            DeletedAt = product.DeletedAt
        };

        public static Product ToEntity(this ProductDto productDto, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository) => new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            BarCode = productDto.BarCode,
            Category = categoryRepository.GetById(productDto.CategoryId),
            Manufacturer = manufacturerRepository.GetById(productDto.ManufacturerId),
            CreatedAt = productDto.CreatedAt,
            UpdatedAt = productDto.UpdatedAt,
            DeletedAt = productDto.DeletedAt
        };
    }
}