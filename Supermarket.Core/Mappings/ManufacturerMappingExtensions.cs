using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Mappings
{
    public static class ManufacturerMappingExtensions
    {
        public static IList<ManufacturerDto> ToDtos(this IList<Manufacturer> manufacturers) => manufacturers.Select(manufacturer => manufacturer.ToDto()).ToList();

        public static IList<Manufacturer> ToEntities(this IList<ManufacturerDto> manufacturerDtos) => manufacturerDtos.Select(manufacturerDto => manufacturerDto.ToEntity()).ToList();

        public static ManufacturerDto ToDto(this Manufacturer manufacturer) => manufacturer == null ? null : new ManufacturerDto
        {
            Id = manufacturer.Id,
            Name = manufacturer.Name,
            OriginCountry = manufacturer.OriginCountry,
            CreatedAt = manufacturer.CreatedAt,
            UpdatedAt = manufacturer.UpdatedAt,
            DeletedAt = manufacturer.DeletedAt
        };

        public static Manufacturer ToEntity(this ManufacturerDto manufacturerDto) => manufacturerDto == null ? null : new Manufacturer
        {
            Id = manufacturerDto.Id,
            Name = manufacturerDto.Name,
            OriginCountry = manufacturerDto.OriginCountry,
            CreatedAt = manufacturerDto.CreatedAt,
            UpdatedAt = manufacturerDto.UpdatedAt,
            DeletedAt = manufacturerDto.DeletedAt
        };
    }
}