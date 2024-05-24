using Supermarket.Core.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IList<CategoryDto> GetAll();
        
        CategoryDto GetById(Guid id);
        
        CategoryDto Add(CategoryDto category);
        
        CategoryDto UpdateById(CategoryDto category, Guid id);
        
        CategoryDto DeleteById(Guid id);
    }
}