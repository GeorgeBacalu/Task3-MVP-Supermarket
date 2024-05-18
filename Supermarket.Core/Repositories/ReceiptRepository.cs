using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly SupermarketDbContext _context;

        public ReceiptRepository(SupermarketDbContext context) => _context = context;

        public IList<Receipt> GetAll() => _context.Receipts
            .Where(receipt => receipt.DeletedAt == null)
            .OrderBy(receipt => receipt.CreatedAt)
            .ToList();

        public Receipt GetById(Guid id) => _context.Receipts
            .Where(receipt => receipt.DeletedAt == null)
            .FirstOrDefault(receipt => receipt.Id == id)
            ?? throw new Exception($"Receipt with id {id} not found");

        public Receipt Add(Receipt receipt)
        {
            receipt.CreatedAt = DateTime.Now;
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            return receipt;
        }

        public Receipt UpdateById(Receipt receipt, Guid id)
        {
            Receipt receiptToUpdate = GetById(id);
            receiptToUpdate.IssuedAt = receipt.IssuedAt;
            receiptToUpdate.Total = receipt.Total;
            if (_context.Entry(receiptToUpdate).State == EntityState.Modified)
                receiptToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return receiptToUpdate;
        }

        public Receipt DeleteById(Guid id)
        {
            Receipt receiptToDelete = GetById(id);
            receiptToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return receiptToDelete;
        }
    }
}