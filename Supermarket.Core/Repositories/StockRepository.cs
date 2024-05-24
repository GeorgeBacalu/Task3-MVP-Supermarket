using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly SupermarketDbContext _context;

        public StockRepository(SupermarketDbContext context) => _context = context;

        public IList<Stock> GetAll() => _context.Stocks
            .Include(stock => stock.Product)
            .Where(stock => stock.DeletedAt == null)
            .OrderBy(stock => stock.CreatedAt)
            .ToList();

        public Stock GetById(Guid id) => _context.Stocks
            .Include(stock => stock.Product)
            .Where(stock => stock.DeletedAt == null)
            .FirstOrDefault(stock => stock.Id == id)
            ?? throw new Exception($"Stock with id {id} not found");

        public Stock Add(Stock stock)
        {
            if (stock.Id == Guid.Empty) stock.Id = Guid.NewGuid();
            stock.CreatedAt = DateTime.Now;
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return stock;
        }

        public Stock UpdateById(Stock stock, Guid id)
        {
            Stock stockToUpdate = GetById(id);
            stockToUpdate.Quantity = stock.Quantity;
            stockToUpdate.MeasureUnit = stock.MeasureUnit;
            stockToUpdate.SuppliedAt = stock.SuppliedAt;
            stockToUpdate.ExpiresAt = stock.ExpiresAt;
            stockToUpdate.PurchasePrice = stock.PurchasePrice;
            stockToUpdate.SalePrice = stock.SalePrice;
            if (_context.Entry(stockToUpdate).State == EntityState.Modified)
                stockToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return stockToUpdate;
        }

        public Stock DeleteById(Guid id)
        {
            Stock stockToDelete = GetById(id);
            stockToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return stockToDelete;
        }
    }
}