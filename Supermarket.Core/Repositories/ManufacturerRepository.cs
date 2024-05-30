using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly SupermarketDbContext _context;

        public ManufacturerRepository(SupermarketDbContext context) => _context = context;

        public IList<Manufacturer> GetAll() => _context.Manufacturers
            .Where(manufacturer => manufacturer.DeletedAt == null)
            .OrderBy(manufacturer => manufacturer.CreatedAt)
            .ToList();

        public IList<Manufacturer> GetByNameContains(string name) => _context.Manufacturers
            .Where(manufacturer => manufacturer.DeletedAt == null && manufacturer.Name.Contains(name))
            .OrderBy(manufacturer => manufacturer.CreatedAt)
            .ToList();

        public Manufacturer GetById(Guid id) => _context.Manufacturers
            .Where(manufacturer => manufacturer.DeletedAt == null)
            .FirstOrDefault(manufacturer => manufacturer.Id == id)
            ?? throw new Exception($"Manufacturer with id {id} not found");

        public Manufacturer Add(Manufacturer manufacturer)
        {
            if (manufacturer.Id == Guid.Empty) manufacturer.Id = Guid.NewGuid();
            manufacturer.CreatedAt = DateTime.Now;
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
            return manufacturer;
        }

        public Manufacturer UpdateById(Manufacturer manufacturer, Guid id)
        {
            Manufacturer manufacturerToUpdate = GetById(id);
            manufacturerToUpdate.Name = manufacturer.Name;
            manufacturerToUpdate.OriginCountry = manufacturer.OriginCountry;
            if (_context.Entry(manufacturerToUpdate).State == EntityState.Modified)
                manufacturerToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return manufacturerToUpdate;
        }

        public Manufacturer DeleteById(Guid id)
        {
            Manufacturer manufacturerToDelete = GetById(id);
            manufacturerToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return manufacturerToDelete;
        }
    }
}