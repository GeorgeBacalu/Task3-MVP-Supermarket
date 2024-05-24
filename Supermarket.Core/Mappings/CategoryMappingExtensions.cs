using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class CategoryMappingExtensions
    {
        public static IList<CategoryDto> ToDtos(this IList<Category> categories) => categories.Select(category => category.ToDto()).ToList();

        public static IList<Category> ToEntities(this IList<CategoryDto> categoryDtos) => categoryDtos.Select(categoryDto => categoryDto.ToEntity()).ToList();

        public static CategoryDto ToDto(this Category category) => category == null ? null : new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
            DeletedAt = category.DeletedAt
        };

        public static Category ToEntity(this CategoryDto categoryDto) => categoryDto == null ? null : new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            CreatedAt = categoryDto.CreatedAt,
            UpdatedAt = categoryDto.UpdatedAt,
            DeletedAt = categoryDto.DeletedAt
        };
    }
}