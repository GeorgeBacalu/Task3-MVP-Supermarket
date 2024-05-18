using Supermarket.Core.Dtos;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class SoldProductService : ISoldProductService
    {
        private readonly ISoldProductRepository _soldProductRepository;
        private readonly IProductRepository _productRepository;

        public SoldProductService(ISoldProductRepository soldProductRepository, IProductRepository productRepository) => (_soldProductRepository, _productRepository) = (soldProductRepository, productRepository);

        public IList<SoldProductDto> GetAll() => _soldProductRepository.GetAll().ToDtos();

        public SoldProductDto GetById(Guid id) => _soldProductRepository.GetById(id).ToDto();

        public SoldProductDto Add(SoldProductDto soldProductDto) => _soldProductRepository.Add(soldProductDto.ToEntity(_productRepository)).ToDto();

        public SoldProductDto UpdateById(SoldProductDto soldProductDto, Guid id) => _soldProductRepository.UpdateById(soldProductDto.ToEntity(_productRepository), id).ToDto();

        public SoldProductDto DeleteById(Guid id) => _soldProductRepository.DeleteById(id).ToDto();
    }
}