using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class OfferDto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public Guid ProductId { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
    }
}