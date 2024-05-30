using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public IList<CategoryDto> GetAll() => _categoryRepository.GetAll().ToDtos();

        public IList<CategoryDto> GetByKey(string key) => _categoryRepository.GetByNameContains(key).ToDtos();

        public CategoryDto GetById(Guid id) => _categoryRepository.GetById(id).ToDto();

        public CategoryDto Add(CategoryDto category) => _categoryRepository.Add(category.ToEntity()).ToDto();

        public CategoryDto UpdateById(CategoryDto category, Guid id) => _categoryRepository.UpdateById(category.ToEntity(), id).ToDto();

        public CategoryDto DeleteById(Guid id) => _categoryRepository.DeleteById(id).ToDto();
    }
}