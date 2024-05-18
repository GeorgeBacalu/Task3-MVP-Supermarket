using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class ProductDto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public ProductCategory Category { get; set; }
        public Guid ManufacturerId { get; set; }
    }
}