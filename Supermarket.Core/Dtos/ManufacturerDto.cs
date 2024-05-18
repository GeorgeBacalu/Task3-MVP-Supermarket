using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos
{
    public class ManufacturerDto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
    }
}