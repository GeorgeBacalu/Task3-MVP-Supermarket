using Supermarket.Core.Dtos;
using Supermarket.Core.Mappings;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository) => _manufacturerRepository = manufacturerRepository;

        public IList<ManufacturerDto> GetAll() => _manufacturerRepository.GetAll().ToDtos();

        public ManufacturerDto GetById(Guid id) => _manufacturerRepository.GetById(id).ToDto();

        public ManufacturerDto Add(ManufacturerDto manufacturerDto) => _manufacturerRepository.Add(manufacturerDto.ToEntity()).ToDto();

        public ManufacturerDto UpdateById(ManufacturerDto manufacturerDto, Guid id) => _manufacturerRepository.UpdateById(manufacturerDto.ToEntity(), id).ToDto();

        public ManufacturerDto DeleteById(Guid id) => _manufacturerRepository.DeleteById(id).ToDto();
    }
}