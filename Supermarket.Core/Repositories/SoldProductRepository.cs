using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class SoldProductRepository : ISoldProductRepository
    {
        private readonly SupermarketDbContext _context;

        public SoldProductRepository(SupermarketDbContext context) => _context = context;

        public IList<SoldProduct> GetAll() => _context.SoldProducts
            .Include(soldProduct => soldProduct.Product)
            .Where(soldProduct => soldProduct.DeletedAt == null)
            .OrderBy(soldProduct => soldProduct.CreatedAt)
            .ToList();

        public SoldProduct GetById(Guid id) => _context.SoldProducts
            .Include(soldProduct => soldProduct.Product)
            .Where(soldProduct => soldProduct.DeletedAt == null)
            .FirstOrDefault(soldProduct => soldProduct.Id == id)
            ?? throw new Exception($"SoldProduct with id {id} not found");

        public SoldProduct Add(SoldProduct soldProduct)
        {
            soldProduct.CreatedAt = DateTime.Now;
            _context.SoldProducts.Add(soldProduct);
            _context.SaveChanges();
            return soldProduct;
        }

        public SoldProduct UpdateById(SoldProduct soldProduct, Guid id)
        {
            SoldProduct soldProductToUpdate = GetById(id);
            soldProductToUpdate.Quantity = soldProduct.Quantity;
            soldProductToUpdate.Subtotal = soldProduct.Subtotal;
            if (_context.Entry(soldProductToUpdate).State == EntityState.Modified)
                soldProductToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return soldProductToUpdate;
        }

        public SoldProduct DeleteById(Guid id)
        {
            SoldProduct soldProductToDelete = GetById(id);
            soldProductToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return soldProductToDelete;
        }
    }
}