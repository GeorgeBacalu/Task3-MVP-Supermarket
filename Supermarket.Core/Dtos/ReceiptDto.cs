using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Dtos
{
    public class ReceiptDto : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public Guid IssuerId { get; set; }
        public IList<Guid> SoldProductsIds { get; set; }
        public decimal Total { get; set; }
        public IList<Guid> StocksIds { get; set; }
    }
}