using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos.Common
{
    public class CategoryDto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}