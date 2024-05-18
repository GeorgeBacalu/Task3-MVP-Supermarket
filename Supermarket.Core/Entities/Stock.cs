﻿using System;

namespace Supermarket.Core.Entities
{
    public class Stock : BaseEntity
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public DateTime SuppliedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }

    public enum MeasureUnit { Piece, Kilogram, Gram, Liter, Milliliter, Other }
}