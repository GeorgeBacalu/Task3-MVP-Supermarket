using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class ReceiptMappingExtensions
    {
        public static IList<ReceiptDto> ToDtos(this IList<Receipt> receipts) => receipts.Select(receipt => receipt.ToDto()).ToList();

        public static IList<Receipt> ToEntities(this IList<ReceiptDto> receiptDtos, IUserRepository userRepository, ISoldProductRepository soldProductRepository) => 
            receiptDtos.Select(receiptDto => receiptDto.ToEntity(userRepository, soldProductRepository)).ToList();

        public static ReceiptDto ToDto(this Receipt receipt) => receipt == null ? null : new ReceiptDto
        {
            Id = receipt.Id,
            IssuedAt = receipt.IssuedAt,
            IssuerId = receipt.Issuer?.Id ?? Guid.Empty,
            SoldProductsIds = receipt.SoldProducts?.Select(soldProduct => soldProduct.Id).ToList() ?? new List<Guid>(),
            Total = receipt.Total,
            CreatedAt = receipt.CreatedAt,
            UpdatedAt = receipt.UpdatedAt,
            DeletedAt = receipt.DeletedAt
        };

        public static Receipt ToEntity(this ReceiptDto receiptDto, IUserRepository userRepository, ISoldProductRepository soldProductRepository) => receiptDto == null ? null : new Receipt
        {
            Id = receiptDto.Id,
            IssuedAt = receiptDto.IssuedAt,
            Issuer = receiptDto.IssuerId == Guid.Empty ? null : userRepository.GetById(receiptDto.IssuerId),
            SoldProducts = receiptDto.SoldProductsIds?.Select(soldProductRepository.GetById).ToList() ?? new List<SoldProduct>(),
            Total = receiptDto.Total,
            CreatedAt = receiptDto.CreatedAt,
            UpdatedAt = receiptDto.UpdatedAt,
            DeletedAt = receiptDto.DeletedAt
        };
    }
}