﻿using Supermarket.Core.Dtos.Common;
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

        public IList<OfferDto> GetByKey(string key) => _offerRepository.GetByProductNameContains(key).ToDtos();

        public OfferDto GetById(Guid id) => _offerRepository.GetById(id).ToDto();

        public OfferDto Add(OfferDto offerDto) => _offerRepository.Add(offerDto.ToEntity(_productRepository)).ToDto();

        public OfferDto UpdateById(OfferDto offerDto, Guid id) => _offerRepository.UpdateById(offerDto.ToEntity(_productRepository), id).ToDto();

        public OfferDto DeleteById(Guid id) => _offerRepository.DeleteById(id).ToDto();
    }
}