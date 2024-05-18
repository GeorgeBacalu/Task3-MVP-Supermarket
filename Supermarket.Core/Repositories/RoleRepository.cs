using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SupermarketDbContext _context;

        public RoleRepository(SupermarketDbContext context) => _context = context;

        public IList<Role> GetAll() => _context.Roles
            .Where(role => role.DeletedAt == null)
            .OrderBy(role => role.CreatedAt)
            .ToList();

        public Role GetById(int id) => _context.Roles
            .Where(role => role.DeletedAt == null)
            .FirstOrDefault(role => role.Id == id)
            ?? throw new Exception($"Role with id {id} not found");

        public Role Add(Role role)
        {
            role.CreatedAt = DateTime.Now;
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }
    }
}