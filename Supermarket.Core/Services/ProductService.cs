using Supermarket.Core.Dtos.Common;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IStockRepository _stockRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository, IStockRepository stockRepository) =>
            (_productRepository, _categoryRepository, _manufacturerRepository, _stockRepository) = (productRepository, categoryRepository, manufacturerRepository, stockRepository);

        public IList<ProductDto> GetAll() => _productRepository.GetAll().ToDtos();

        public IList<ProductDto> GetByKey(string key) => _productRepository.GetByNameContains(key).ToDtos();

        public ProductDto GetById(Guid id) => _productRepository.GetById(id).ToDto();

        public ProductDto Add(ProductDto productDto) => _productRepository.Add(productDto.ToEntity(_categoryRepository, _manufacturerRepository, _stockRepository)).ToDto();

        public ProductDto UpdateById(ProductDto productDto, Guid id) => _productRepository.UpdateById(productDto.ToEntity(_categoryRepository, _manufacturerRepository, _stockRepository), id).ToDto();

        public ProductDto DeleteById(Guid id) => _productRepository.DeleteById(id).ToDto();
    }
}