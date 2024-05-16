using System;

namespace Supermarket.Core.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public ProductCategory Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }

    public enum ProductCategory { Food, Drink, Cleaning, Electronics, Clothing, Office }
}