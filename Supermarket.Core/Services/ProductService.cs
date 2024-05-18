using Supermarket.Core.Dtos;
using Supermarket.Core.Entities;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ProductDto GetById(Guid id) => _productRepository.GetById(id).ToDto();

        public ProductDto Add(ProductDto productDto) => _productRepository.Add(productDto.ToEntity(_categoryRepository, _manufacturerRepository, _stockRepository)).ToDto();

        public ProductDto UpdateById(ProductDto productDto, Guid id)
        {
            Product updatedProduct = _productRepository.UpdateById(productDto.ToEntity(_categoryRepository, _manufacturerRepository, _stockRepository), id);
            updatedProduct.Category = _categoryRepository.GetById(productDto.CategoryId);
            updatedProduct.Manufacturer = _manufacturerRepository.GetById(productDto.ManufacturerId);
            updatedProduct.Stocks = productDto.StocksIds.Select(_stockRepository.GetById).ToList();
            return updatedProduct.ToDto();
        }

        public ProductDto DeleteById(Guid id) => _productRepository.DeleteById(id).ToDto();
    }
}