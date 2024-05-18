using System;

namespace Supermarket.Core.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ex: Food, Drink, Cleaning, Electronics, Clothing, Office
    }
}