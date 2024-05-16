using System;

namespace Supermarket.Core.Entities
{
    public class Offer : BaseEntity
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public Product Product { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
    }
}