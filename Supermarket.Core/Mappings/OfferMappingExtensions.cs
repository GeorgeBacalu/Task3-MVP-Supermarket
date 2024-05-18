using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class OfferMappingExtensions
    {
        public static IList<OfferDto> ToDtos(this IList<Offer> offers) => offers.Select(offer => offer.ToDto()).ToList();

        public static IList<Offer> ToEntities(this IList<OfferDto> offerDtos, IProductRepository productRepository) => offerDtos.Select(offerDto => offerDto.ToEntity(productRepository)).ToList();

        public static OfferDto ToDto(this Offer offer) => offer == null ? null : new OfferDto
        {
            Id = offer.Id,
            Reason = offer.Reason,
            ProductId = offer.Product.Id,
            Discount = offer.Discount,
            StartsAt = offer.StartsAt,
            EndsAt = offer.EndsAt,
            CreatedAt = offer.CreatedAt,
            UpdatedAt = offer.UpdatedAt,
            DeletedAt = offer.DeletedAt
        };

        public static Offer ToEntity(this OfferDto offerDto, IProductRepository productRepository) => offerDto == null ? null : new Offer
        {
            Id = offerDto.Id,
            Reason = offerDto.Reason,
            Product = productRepository.GetById(offerDto.ProductId),
            Discount = offerDto.Discount,
            StartsAt = offerDto.StartsAt,
            EndsAt = offerDto.EndsAt,
            CreatedAt = offerDto.CreatedAt,
            UpdatedAt = offerDto.UpdatedAt,
            DeletedAt = offerDto.DeletedAt
        };
    }
}