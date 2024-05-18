using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IProductRepository _productRepository;

        public OfferService(IOfferRepository offerRepository, IProductRepository productRepository) => (_offerRepository, _productRepository) = (offerRepository, productRepository);

        public IList<OfferDto> GetAll() => _offerRepository.GetAll().ToDtos();

        public OfferDto GetById(Guid id) => _offerRepository.GetById(id).ToDto();

        public OfferDto Add(OfferDto offerDto) => _offerRepository.Add(offerDto.ToEntity(_productRepository)).ToDto();

        public OfferDto UpdateById(OfferDto offerDto, Guid id)
        {
            Offer updatedOffer = _offerRepository.UpdateById(offerDto.ToEntity(_productRepository), id);
            updatedOffer.Product = _productRepository.GetById(updatedOffer.Product.Id);
            return updatedOffer.ToDto();
        }

        public OfferDto DeleteById(Guid id) => _offerRepository.DeleteById(id).ToDto();
    }
}