using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IManufacturerRepository _manufacturerRepository;

        public ProductService(IProductRepository productRepository, IManufacturerRepository manufacturerRepository) => (_productRepository, _manufacturerRepository) = (productRepository, manufacturerRepository);

        public IList<ProductDto> GetAll() => _productRepository.GetAll().ToDtos();

        public ProductDto GetById(Guid id) => _productRepository.GetById(id).ToDto();

        public ProductDto Add(ProductDto productDto) => _productRepository.Add(productDto.ToEntity(_manufacturerRepository)).ToDto();

        public ProductDto UpdateById(ProductDto productDto, Guid id)
        {
            Product updatedProduct = _productRepository.UpdateById(productDto.ToEntity(_manufacturerRepository), id);
            updatedProduct.Manufacturer = _manufacturerRepository.GetById(productDto.ManufacturerId);
            return updatedProduct.ToDto();
        }

        public ProductDto DeleteById(Guid id) => _productRepository.DeleteById(id).ToDto();
    }
}