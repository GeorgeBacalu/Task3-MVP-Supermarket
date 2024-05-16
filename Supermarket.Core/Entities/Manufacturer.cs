using System;

namespace Supermarket.Core.Entities
{
    public class Manufacturer : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
    }
}