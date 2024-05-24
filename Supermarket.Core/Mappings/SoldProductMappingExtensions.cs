using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class SoldProductMappingExtensions
    {
        public static IList<SoldProductDto> ToDtos(this IList<SoldProduct> soldProducts) => soldProducts.Select(soldProduct => soldProduct.ToDto()).ToList();

        public static IList<SoldProduct> ToEntities(this IList<SoldProductDto> soldProductDtos, IProductRepository productRepository) => soldProductDtos.Select(soldProductDto => soldProductDto.ToEntity(productRepository)).ToList();

        public static SoldProductDto ToDto(this SoldProduct soldProduct) => soldProduct == null ? null : new SoldProductDto
        {
            Id = soldProduct.Id,
            ProductId = soldProduct.Product.Id,
            Quantity = soldProduct.Quantity,
            Subtotal = soldProduct.Subtotal,
            CreatedAt = soldProduct.CreatedAt,
            UpdatedAt = soldProduct.UpdatedAt,
            DeletedAt = soldProduct.DeletedAt
        };

        public static SoldProduct ToEntity(this SoldProductDto soldProductDto, IProductRepository productRepository) => soldProductDto == null ? null : new SoldProduct
        {
            Id = soldProductDto.Id,
            Product = productRepository.GetById(soldProductDto.ProductId),
            Quantity = soldProductDto.Quantity,
            Subtotal = soldProductDto.Subtotal,
            CreatedAt = soldProductDto.CreatedAt,
            UpdatedAt = soldProductDto.UpdatedAt,
            DeletedAt = soldProductDto.DeletedAt
        };
    }
}