using System;

namespace Supermarket.Core.Entities
{
    public class SoldProduct : BaseEntity
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}