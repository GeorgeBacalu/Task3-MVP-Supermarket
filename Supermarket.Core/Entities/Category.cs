using System;

namespace Supermarket.Core.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public ProductCategory Name { get; set; }
    }

    public enum ProductCategory { Food, Drink, Cleaning, Electronics, Clothing, Office }
}