using Supermarket.Core.Dtos.Response;
using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IList<Category> GetAll();

        IList<Category> GetByNameContains(string name);
        
        Category GetById(Guid id);
        
        Category Add(Category category);
        
        Category UpdateById(Category category, Guid id);
        
        Category DeleteById(Guid id);

        IList<CategoryValueResponse> ComputeCategoryValues();
    }
}