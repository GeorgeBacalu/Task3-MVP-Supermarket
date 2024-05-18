using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SupermarketDbContext _context;

        public CategoryRepository(SupermarketDbContext context) => _context = context;

        public IList<Category> GetAll() => _context.Categories
            .Where(category => category.DeletedAt == null)
            .OrderBy(category => category.CreatedAt)
            .ToList();

        public Category GetById(Guid id) => _context.Categories
            .Where(category => category.DeletedAt == null)
            .FirstOrDefault(category => category.Id == id)
            ?? throw new Exception($"Category with id {id} not found.");

        public Category Add(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category UpdateById(Category category, Guid id)
        {
            Category categoryToUpdate = GetById(id);
            categoryToUpdate.Name = category.Name;
            if (_context.Entry(categoryToUpdate).State == EntityState.Modified)
                categoryToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return categoryToUpdate;
        }

        public Category DeleteById(Guid id)
        {
            Category categoryToDelete = GetById(id);
            categoryToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return categoryToDelete;
        }
    }
}