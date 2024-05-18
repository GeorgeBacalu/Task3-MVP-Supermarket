using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class SoldProductDto : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}