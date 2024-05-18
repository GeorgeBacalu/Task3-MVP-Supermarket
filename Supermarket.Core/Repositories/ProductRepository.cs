using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SupermarketDbContext _context;

        public ProductRepository(SupermarketDbContext context) => _context = context;

        public IList<Product> GetAll() => _context.Products
            .Where(product => product.DeletedAt == null)
            .OrderBy(product => product.CreatedAt)
            .ToList();

        public Product GetById(Guid id) => _context.Products
            .Where(product => product.DeletedAt == null)
            .FirstOrDefault(product => product.Id == id)
            ?? throw new Exception($"Product with id {id} not found");

        public Product Add(Product product)
        {
            product.CreatedAt = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateById(Product product, Guid id)
        {
            Product productToUpdate = GetById(id);
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.BarCode = product.BarCode;
            productToUpdate.Category = product.Category;
            if (_context.Entry(productToUpdate).State == EntityState.Modified)
                productToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return productToUpdate;
        }

        public Product DeleteById(Guid id)
        {
            Product productToDelete = GetById(id);
            productToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return productToDelete;
        }
    }
}