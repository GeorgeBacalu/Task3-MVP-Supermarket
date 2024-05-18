using System;
using System.Collections.Generic;

namespace Supermarket.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public User Issuer { get; set; }
        public IList<SoldProduct> SoldProducts { get; set; }
        public decimal Total { get; set; }
    }
}