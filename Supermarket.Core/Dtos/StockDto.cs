using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class StockDto : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public DateTime SuppliedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}