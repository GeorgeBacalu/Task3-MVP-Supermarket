using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class CategoryDto : BaseEntity
    {
        public Guid Id { get; set; }
        public ProductCategory Name { get; set; }
    }
}